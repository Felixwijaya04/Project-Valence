using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public GameObject uigameObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        uigameObject.SetActive(true);
    }
}
