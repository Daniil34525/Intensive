using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleChanger : MonoBehaviour
{
    public Camera camera_main;
    private Scrollbar scrollBar;
    private float startView;

    void Start()
    {
        scrollBar = GetComponent<Scrollbar>();
        startView = camera_main.GetGateFittedFieldOfView(); 
    }

    // Update is called once per frame
    void Update()
    {
        camera_main.fieldOfView = startView - (scrollBar.value * 20);
    }
}
