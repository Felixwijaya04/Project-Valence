using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public int totalCoins;
    public Text coinText;

    /*[ContextMenu("Increase")]*/
    public void addCoins(int amount)
    {
        totalCoins += amount;
        coinText.text = totalCoins.ToString();
    }
}
