using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadAnim : MonoBehaviour
{
    [SerializeField] private float maxTimer = 1f;
    [SerializeField] private float Timer = 0f;
    [SerializeField] Image circularUI;
    [SerializeField] bool reloading;

    public ShootingNigger nigger;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && nigger.currentammo < nigger.ammo)
        {
            reloading = true;
            circularUI.enabled = true;
        }
        if (reloading)
        {
            Timer += Time.deltaTime;
            circularUI.fillAmount = Timer;
            if (Timer >= maxTimer)
            {
                Timer = 0f;
                circularUI.fillAmount = Timer;
                circularUI.enabled = false;
                reloading = false;
            }
        }
    }
}
