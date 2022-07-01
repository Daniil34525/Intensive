using UnityEngine;
using UnityEngine.UI;

public class AppInterface : MonoBehaviour
{
    public void CloseApp()
    {
        Debug.Log("CloseApp");
        Application.Quit();
    }

    // Выход из полноэкранного режима.
    //public void ChangeWindowSreen()
    //{
    //    Debug.Log("SwitchScreen"); 
    //    Screen.fullScreen = !Screen.fullScreen; 
    //}
}
