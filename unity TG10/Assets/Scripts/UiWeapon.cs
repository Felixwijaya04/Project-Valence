using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWeapon : MonoBehaviour
{
    public itemBuy validates;
    

    // Update is called once per frame
    void Update()
    {
        if(validates.GetWeapon == true)
        {
            gameObject.SetActive(true);
        }
    }
}
