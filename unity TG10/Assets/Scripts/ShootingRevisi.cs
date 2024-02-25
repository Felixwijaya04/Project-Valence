using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingNigger : MonoBehaviour
{
    /*private Vector3 mousePos;*/
    public GameObject bullet;
    public Transform bulletTransform;
    public bool isFire;
    private float timer;
    public float intervalFiring;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (!isFire)
        {
            timer += Time.deltaTime;
            if (timer > intervalFiring)
            {
                isFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && isFire)
        {
            isFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Pressing();
        }
    }
    public static bool Pressing()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }




}
