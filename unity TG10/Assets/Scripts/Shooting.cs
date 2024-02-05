using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool isFire;
    private float timer;
    public float intervalFiring;
    public GameObject Flash;
    [Range(0,5)]
    public int FramesToFlash = 1;
    bool isflashing = false;
    private CinemachineImpulseSource impulseSource;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Flash.SetActive(false);
        impulseSource = GetComponent<CinemachineImpulseSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        shooting();
    }

    void shooting()
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

        if (Input.GetMouseButton(0) && isFire)
        {
            isFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            CameraShakeManager.instance.CameraShake(impulseSource);
            
            if (!isflashing)
            {
                StartCoroutine(DoFlash());
            }

            /*Instantiate(Flash, bulletTransform.position, Quaternion.identity);*/
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

    IEnumerator DoFlash()
    {
        Flash.SetActive(true);
        var framesFlashed = 0;
        isflashing = true;

        while (framesFlashed <= FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }
        Flash.SetActive(false);
        isflashing = false;
    }
}
