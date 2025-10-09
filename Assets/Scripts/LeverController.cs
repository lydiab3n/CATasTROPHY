using UnityEngine;
using UnityEngine.EventSystems;

public class LeverController : MonoBehaviour
{
    //https://www.youtube.com/watch?v=xDCwdOj49b4


    void Awake()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down on Lever");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag on Lever");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging Lever");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag on Lever");
    }

    
}
