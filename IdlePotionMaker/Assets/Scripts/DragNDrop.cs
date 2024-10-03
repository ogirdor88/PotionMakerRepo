using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 mouseOffset;

    private void Awake()
    {
        startPos = transform.position;
    }

    private Vector3 MousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        //set up the mouse offset
        mouseOffset = Input.mousePosition - MousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mouseOffset);
    }

    private void OnMouseUp()
    {
        transform.position = startPos;
    }
}
