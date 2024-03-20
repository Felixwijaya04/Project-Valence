using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcursor : MonoBehaviour
{
    /*Vector3 targetPos;*/
    public Canvas parentCanvas;

    // Update is called once per frame
    void Update()
    {
        /*targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas.transform, targetPos);*/
        transform.position = Input.mousePosition;
    }

    /*public Vector3 worldToUISpace()
    {
        Vector3 screenpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movepos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform, screenpos, parentCanvas.worldCamera, out movepos);

    }*/
}
