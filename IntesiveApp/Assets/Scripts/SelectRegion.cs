using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRegion : MonoBehaviour
{
    public GameObject region_1;
    public GameObject region_2;
    public GameObject region_3;
    public GameObject Camera;

    public Dropdown dropdown;

    public void GetRegion()
    {
        if (dropdown.value == 0)      Camera.transform.SetPositionAndRotation(region_1.transform.position, region_1.transform.rotation);
        else if (dropdown.value== 1)  Camera.transform.SetPositionAndRotation(region_2.transform.position, region_2.transform.rotation); 
        else if (dropdown.value == 2) Camera.transform.SetPositionAndRotation(region_3.transform.position, region_3.transform.rotation);
    }
}
