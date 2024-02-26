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
    public GameObject Flash;
    [Range(0, 5)]
    public int FramesToFlash = 1;
    bool isflashing = false;

    private void Start()
    {
        Flash.SetActive(false);
    }

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
            if (!isflashing)
            {
                StartCoroutine(DoFlash());
            }
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
