using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public int totalAmmo;
    public Text ammoText;

    public void setAmmo(int ammo)
    {
        totalAmmo = ammo;
        ammoText.text = totalAmmo.ToString();
    }
    [ContextMenu("Decrease")]
    public void updateAmmo(int amount)
    {
        totalAmmo = amount;
        ammoText.text = totalAmmo.ToString();
    }
}
