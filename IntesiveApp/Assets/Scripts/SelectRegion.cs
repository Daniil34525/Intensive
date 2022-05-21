using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRegion : MonoBehaviour
{
    public GameObject region_1;
    public GameObject region_2;
    public GameObject Camera;

    public Dropdown dropdown;

    public void GetRegion()
    {
        if (dropdown.value == 0)
        {
            Camera.transform.position = region_1.transform.position;
        }
        else if (dropdown.value== 1)
        {
            Camera.transform.position = region_2.transform.position;
        }
    }
}
