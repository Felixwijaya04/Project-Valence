using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /*private Camera mainCam;
    private Vector3 mousePos;*/
    public GameObject Mplayer;
    // Start is called before the first frame update
   

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (rotZ < -90 || rotZ > 90)
        {
            /*if (Mplayer.transform.rotation.y == 0)
            {
                Debug.Log("HadapKanan");
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
                

            } else if (Mplayer.transform.localEulerAngles.y == 180 || Mplayer.transform.rotation.y == -180)
            {
                Debug.Log("HadapKiri");
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
                
            }*/
            transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
        }
    }



}
