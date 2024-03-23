using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestScript : MonoBehaviour
{
    public CoinsManager coinUpdate;
    [SerializeField] private int coinsHere;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PopUpPrompts._isplayer == true)
        {
            coin();
        }
    }
    void coin()
    {
        coinUpdate.addCoins(coinsHere);
        coinsHere = 0;
    }
}
