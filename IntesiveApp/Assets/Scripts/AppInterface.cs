using UnityEngine;
using UnityEngine.UI;

public class AppInterface : MonoBehaviour
{
    public void CloseApp()
    {
        Debug.Log("CloseApp");
        Application.Quit();
    }

    // ����� �� �������������� ������.
    //public void ChangeWindowSreen()
    //{
    //    Debug.Log("SwitchScreen"); 
    //    Screen.fullScreen = !Screen.fullScreen; 
    //}
}
