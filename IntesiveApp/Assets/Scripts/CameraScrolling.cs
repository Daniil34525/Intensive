using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CameraScrolling : MonoBehaviour
{
    private float current_x;
    private float current_y; 
    private Vector3 rotateValue;
    public Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            current_x = Input.GetAxis("Mouse X");
            rotateValue = new Vector3(0, current_x * -1, 0);
            _camera.transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
    }

    public void OnPointerDown()
    {
        throw new NotImplementedException();
    }
}

