using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool isFire;
    private float timer;
    public float intervalFiring;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!isFire)
        {
            timer += Time.deltaTime;
            if (timer > intervalFiring)
            {
                isFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && isFire)
        {
            isFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
