using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickForCanvasChange : MonoBehaviour, IPointerClickHandler
{
    // ���� ������, ���� � Unity:
    public GameObject canvas_insert;
    public GameObject canvas_main;
  
    
    public void OnPointerClick(PointerEventData eventData) // ��������� ������� �� �������.
    {
        //_text.text = "��� ��� �������!\n�� ������ ��� ����!";
        Debug.Log("Click received");  
        // ����� canvas � main �� insert � ��������.
        canvas_insert.SetActive(!canvas_insert.activeSelf); 
        canvas_main.SetActive(!canvas_main.activeSelf);
    }
}
