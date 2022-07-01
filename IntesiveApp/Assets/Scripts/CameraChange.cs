using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Drawing; 

public class CameraChange : MonoBehaviour
{
    public DateAndInfo dateAndInfo; // Второй скрипт с картинками и текстами.

    #region Доступные поля класса
    // Поля класса, виды в Unity:
    public Camera mainCamera;      // Камера сцены.
    public Camera forObjectCamera; // Камера на объект с канвасом.
    public Camera rotativeCamera;  // Камера на пустой объект (вращающаяся).
    public GameObject emptyObject; // Пустой объект, за которым закреплена камера.
    public Text objectInfo;        // Поле с тексом по объекту.
    public Image objectSprite;     // Поле с изображением по объекту.
    public Canvas canvasWithRegions; 
    #endregion

    private Quaternion startAngles;     // Хранит начальные углы поворота.
    private bool rotationFlag = false;  // Флаг для поворота.

    public void OnMouseDown()
    {
        // В зависими от тега объекта, по которому мы нажали:
        switch (gameObject.tag)
        {
            case "Tower":
                objectSprite.sprite = dateAndInfo.SpriteForTower;
                objectInfo.text = dateAndInfo.TowerInfo.text; 
                break;
            case "HomeBorsheva":
                objectSprite.sprite = dateAndInfo.SpriteForHomeBorheva;
                objectInfo.text =dateAndInfo.HomeBorshevaInfo.text;
                break;
            case "GuardHouse":
                objectSprite.sprite = dateAndInfo.SpriteForGuardHouse;
                objectInfo.text = dateAndInfo.GuardHouseInfo.text;
                break;
            case "Besedka":
                objectSprite.sprite = dateAndInfo.SpriteForBesedka;
                objectInfo.text = dateAndInfo.BesedkaInfo.text;
                break;
            case "Ostrov":
                objectSprite.sprite = dateAndInfo.SpriteForOstrov;
                objectInfo.text = dateAndInfo.OstrovInfo.text;
                break;
        }

        // Если камера сцены сейчас включена: 
        if (mainCamera.enabled)
        {
            SwitchToSupportCam();
            return;
        }

        if (!rotationFlag)
        {
            rotationFlag = !rotationFlag; // Меняем флаг на true.
            forObjectCamera.enabled = !forObjectCamera.enabled; // Отключение камеры с конвасом на объект.
            rotativeCamera.enabled = !rotativeCamera.enabled;  // Включение камеры кращения.
        }
        else
        {
            rotationFlag = !rotationFlag; // Меняем флаг на false.
            forObjectCamera.enabled = !forObjectCamera.enabled; // Включение камера на объект с канвасом.
            rotativeCamera.enabled = !rotativeCamera.enabled; // Отключение камеры вращения. 
            emptyObject.transform.rotation = startAngles;
        }
    }

    private void Update() { if (rotationFlag) emptyObject.transform.Rotate(0, -15 * Time.deltaTime, 0); }
    
    private void SwitchToSupportCam()
    {
        mainCamera.enabled = !mainCamera.enabled; // Отключение камеры на сцену.
        canvasWithRegions.enabled = !canvasWithRegions.enabled;
        forObjectCamera.enabled = !forObjectCamera.enabled; // Включение камера на объект с канвасом.
       
        ExposeTheRotativeObject(); // Вызов метода для выставление пустого объекта на сцене.

        // Позиция и углы поворота камеры вращения автоматически выставлены относительно пустого объекта.
        forObjectCamera.transform.SetPositionAndRotation(
            rotativeCamera.transform.position,  // Позиция камеры на объект = позиция камеры вращения.
            rotativeCamera.transform.rotation); // Углы поворота камеры на объекта = углы поворота камеры вращения.
    }

    private void ExposeTheRotativeObject()
    {
        startAngles = transform.rotation; // Берем углы поворота объекта, на который нажали. 
        
        // Задаем позицию для пустого объекта такую же, как и у объекта на который нажали.
        // Углы поворота берем такие же, как и у объекта на сцене, на который мы нажали. 
        emptyObject.transform.SetPositionAndRotation(
            new Vector3(transform.position.x, transform.position.y, transform.position.z), // Установка позиции.
            startAngles);                                                                  // Установка углов поворота.
    }
    public void Exit() // Для выхода на камеру сцены.
    {
        rotativeCamera.enabled = false;
        forObjectCamera.enabled = false;
        mainCamera.enabled = true;
        canvasWithRegions.enabled = true; 
    }
}
