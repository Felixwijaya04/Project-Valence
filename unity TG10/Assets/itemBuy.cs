using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemBuy : MonoBehaviour
{
    [SerializeField] private int price;
    public int hpAdd = 15;
    public int armorAdd = 10;
    public CoinsManager CoinsManager;
    public PlayerMovement pm;
    public void buyHP()
    {
        if(CoinsManager.totalCoins >= price)
        {
            CoinsManager.addCoins(-price);
            pm.maxHealth += hpAdd;
            pm.currentHealth = pm.maxHealth;
        }
    }

    public void buyArmor()
    {
        if(CoinsManager.totalCoins >= price)
        {
            CoinsManager.addCoins(-price);
        }
        
    }
}
