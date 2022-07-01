using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    public int date;
    public Text text;
    public void activ()
    {
        if (!gameObject.activeSelf && int.Parse(text.text.Remove(text.text.Length-3)) > date) gameObject.SetActive(true);
        else if (int.Parse(text.text.Remove(text.text.Length - 3)) < date) gameObject.SetActive(false);
    }
}
