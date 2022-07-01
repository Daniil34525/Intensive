using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDate : MonoBehaviour
{
    public Text text;
    public Scrollbar scrollbar;
    public void setDate()
    {
        text.text = (((int)(1800 + scrollbar.value * 222)).ToString()) + " год";
    }
}
