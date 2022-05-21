using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickForCanvasChange : MonoBehaviour, IPointerClickHandler
{
    // Поля класса, виды в Unity:
    public GameObject canvas_insert;
    public GameObject canvas_main;
  
    
    public void OnPointerClick(PointerEventData eventData) // Обработка нажатия по объекту.
    {
        //_text.text = "ЭТО ДОМ БОРЩОВА!\nОн сейчас ест борщ!";
        Debug.Log("Click received");  

        // Смена canvas с main на insert и наоборот.
        canvas_insert.SetActive(!canvas_insert.activeSelf); 
        canvas_main.SetActive(!canvas_main.activeSelf);
       
    }
    void Start()
    {
        //Debug.Log("Click received");
        //canvas_dop.SetActive(!canvas_dop.activeSelf);
        //canvas_main.SetActive(!canvas_main.activeSelf);//false
    }
    
    void Update()
    {
        
    }
}
