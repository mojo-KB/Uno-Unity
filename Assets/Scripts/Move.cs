using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHold = false;

    Vector3 mousePos;


    // Update is called once per frame
    void Update()
    {
        if (isBeingHold)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }

        
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y;

        isBeingHold = true;
    }

    private void OnMouseUp()
    {
        isBeingHold = false;
    }

}
