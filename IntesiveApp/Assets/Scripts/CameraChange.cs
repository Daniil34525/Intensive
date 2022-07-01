using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Drawing; 

public class CameraChange : MonoBehaviour
{
    public DateAndInfo dateAndInfo; // ������ ������ � ���������� � ��������.

    #region ��������� ���� ������
    // ���� ������, ���� � Unity:
    public Camera mainCamera;      // ������ �����.
    public Camera forObjectCamera; // ������ �� ������ � ��������.
    public Camera rotativeCamera;  // ������ �� ������ ������ (�����������).
    public GameObject emptyObject; // ������ ������, �� ������� ���������� ������.
    public Text objectInfo;        // ���� � ������ �� �������.
    public Image objectSprite;     // ���� � ������������ �� �������.
    public Canvas canvasWithRegions; 
    #endregion

    private Quaternion startAngles;     // ������ ��������� ���� ��������.
    private bool rotationFlag = false;  // ���� ��� ��������.

    public void OnMouseDown()
    {
        // � �������� �� ���� �������, �� �������� �� ������:
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

        // ���� ������ ����� ������ ��������: 
        if (mainCamera.enabled)
        {
            SwitchToSupportCam();
            return;
        }

        if (!rotationFlag)
        {
            rotationFlag = !rotationFlag; // ������ ���� �� true.
            forObjectCamera.enabled = !forObjectCamera.enabled; // ���������� ������ � �������� �� ������.
            rotativeCamera.enabled = !rotativeCamera.enabled;  // ��������� ������ ��������.
        }
        else
        {
            rotationFlag = !rotationFlag; // ������ ���� �� false.
            forObjectCamera.enabled = !forObjectCamera.enabled; // ��������� ������ �� ������ � ��������.
            rotativeCamera.enabled = !rotativeCamera.enabled; // ���������� ������ ��������. 
            emptyObject.transform.rotation = startAngles;
        }
    }

    private void Update() { if (rotationFlag) emptyObject.transform.Rotate(0, -15 * Time.deltaTime, 0); }
    
    private void SwitchToSupportCam()
    {
        mainCamera.enabled = !mainCamera.enabled; // ���������� ������ �� �����.
        canvasWithRegions.enabled = !canvasWithRegions.enabled;
        forObjectCamera.enabled = !forObjectCamera.enabled; // ��������� ������ �� ������ � ��������.
       
        ExposeTheRotativeObject(); // ����� ������ ��� ����������� ������� ������� �� �����.

        // ������� � ���� �������� ������ �������� ������������� ���������� ������������ ������� �������.
        forObjectCamera.transform.SetPositionAndRotation(
            rotativeCamera.transform.position,  // ������� ������ �� ������ = ������� ������ ��������.
            rotativeCamera.transform.rotation); // ���� �������� ������ �� ������� = ���� �������� ������ ��������.
    }

    private void ExposeTheRotativeObject()
    {
        startAngles = transform.rotation; // ����� ���� �������� �������, �� ������� ������. 
        
        // ������ ������� ��� ������� ������� ����� ��, ��� � � ������� �� ������� ������.
        // ���� �������� ����� ����� ��, ��� � � ������� �� �����, �� ������� �� ������. 
        emptyObject.transform.SetPositionAndRotation(
            new Vector3(transform.position.x, transform.position.y, transform.position.z), // ��������� �������.
            startAngles);                                                                  // ��������� ����� ��������.
    }
    public void Exit() // ��� ������ �� ������ �����.
    {
        rotativeCamera.enabled = false;
        forObjectCamera.enabled = false;
        mainCamera.enabled = true;
        canvasWithRegions.enabled = true; 
    }
}
