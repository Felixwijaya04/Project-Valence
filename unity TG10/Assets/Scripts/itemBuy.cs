using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemBuy : MonoBehaviour
{
    [SerializeField] private int price;
    public int hpAdd;
    public int armorAdd;
    public CoinsManager CoinsManager;
    public PlayerMovement pm;
    public BarArmor barArmor;
    public bool GetWeapon = false;
    public GameObject Uiweapons;
    public void buyHP()
    {
        if(CoinsManager.totalCoins >= price)
        {
            CoinsManager.addCoins(-price);
            pm.currentHealth += hpAdd;
            pm.currentHealth = Mathf.Clamp(pm.currentHealth, 0, pm.maxHealth);
        }
    }

    public void buyArmor()
    {
        if(CoinsManager.totalCoins >= price)
        {
            CoinsManager.addCoins(-price);
            pm.currentarmor += armorAdd;
            pm.currentarmor = Mathf.Clamp(pm.currentarmor, 0, pm.maxarmor);
            barArmor.setCurrentarmor(pm.currentarmor);
        }
        
    }

    public void buyHParmor()
    {
        if (CoinsManager.totalCoins >= price)
        {
            // Armor
            CoinsManager.addCoins(-price);
            pm.currentarmor += armorAdd;
            pm.currentarmor = Mathf.Clamp(pm.currentarmor, 0, pm.maxarmor);
            barArmor.setCurrentarmor(pm.currentarmor);
            // HP
            pm.currentHealth += hpAdd;
            pm.currentHealth = Mathf.Clamp(pm.currentHealth, 0, pm.maxHealth);
        }
    }

    public void buyweapon()
    {
        if (CoinsManager.totalCoins >= price)
        {
            CoinsManager.addCoins(-price);
            GetWeapon = true;
            Uiweapons.SetActive(true);
            
        }
    }
}
