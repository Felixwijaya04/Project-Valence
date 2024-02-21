using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private GameObject currentTeleporter;
    private TeleportStair tStair;
    // void Awake(){
    //     tStair = currentTeleporter.GetComponent<tStair>();
    // }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(tStair.key)){
        //     transform.position = tStair.destination.position;
        // }
        // if(Input.GetKeyDown(tStair.key2)){
        //     transform.position = tStair.destination2.position;
        // }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<TeleportStair>().GetDestinationUp().position;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<TeleportStair>().GetDestinationDown().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
