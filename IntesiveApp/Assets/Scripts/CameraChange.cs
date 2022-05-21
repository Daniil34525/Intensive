using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Drawing; 

public class CameraChange : MonoBehaviour, IPointerClickHandler
{
    // Поля класса, виды в Unity:
    public GameObject camera_main;      // Камера сцены.
    public GameObject camera_object;    // Камера на объект с канвасом.
    public GameObject camera_rotative;  // Камера на пустой объект (вращающаяся).
    public GameObject emptyObject;      // Пустой объект, за которым закреплена камера.

    private Quaternion startAngles;     // Хранит начальные углы поворота.
    private bool flag = false;          // Флаг для поворота.

    public Text information;
    public Image picture; 

    private static string pathForTxt = @"Assets\Information\";

    public Sprite tower;
    public Sprite guardHouse;
    public Sprite homeBorsheva;
    public Sprite besedka;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.tag + ".txt"); 

        information.text = File.ReadAllText(pathForTxt + gameObject.tag + ".txt");

        switch (gameObject.tag)
        {
            case "Tower":
                picture.sprite = tower;
                break;
            case "HomeBorsheva":
                picture.sprite = homeBorsheva;
                break;
            case "GuardHouse":
                picture.sprite = guardHouse;
                break;
            case "Besedka":
                picture.sprite = besedka;
                break;
        }
        
        if (camera_main.activeSelf)
        {
            camera_main.SetActive(false); // Отключение камеры на сцену.
            camera_object.SetActive(true); // Включение камеры на объект с канвасом.

            startAngles = transform.rotation;  // Берем углы поворота объекта, на который нажали.
            // Высталение пустого объекта:
            emptyObject.transform.rotation = startAngles; // Выставляем полученные угла на пустой объект.
            // Задаем позицию для пустого объекта такую же, как и у объекта на который нажали.
            emptyObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // Камера на пустой объект будет выставлена автоматически.

            // Выставляем камеру с конвасом на объект по мировым координатам камеры, которая направлена на пустой объект.
            camera_object.transform.rotation = camera_rotative.transform.rotation;
            camera_object.transform.position = camera_rotative.transform.position;
            return; 
        }
        if (!flag) 
        { 
            flag = !flag;
            camera_object.SetActive(!camera_object.activeSelf); 
            camera_rotative.SetActive(!camera_rotative.activeSelf);
            Debug.Log("Start Rotation"); 
        }
        else
        {
            flag = !flag;
            camera_object.SetActive(!camera_object.activeSelf);
            camera_rotative.SetActive(!camera_rotative.activeSelf); 
            emptyObject.transform.rotation = startAngles;   
            Debug.Log("Stop rotation!");
        }
    }

    private void Update() { if (flag) emptyObject.transform.Rotate(0, -25 * Time.deltaTime, 0); }

    public void Exit() // Для выхода на камеру сцены.
    {
        camera_rotative.SetActive(false);  
        camera_object.SetActive(false);
        camera_main.SetActive(true); 
    }
}
