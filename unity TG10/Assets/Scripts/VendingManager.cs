using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VendingManager : MonoBehaviour
{
    public GameObject VendingUI;
    public Behaviour playerscript;
    private bool _isplayer = false;
    public GameObject RotateP;
    public GameObject TargetShoot;
    // Start is called before the first frame update
    void Start()
    {
        /*VendingUI.gameObject.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _isplayer == true)
        {
            VendingUI.gameObject.SetActive(true);
            //disabled player movement when shop ui is open
            /*playerscript.enabled = false;*/
            TargetShoot.GetComponent<ShootingNigger>().enabled = false;
            RotateP.GetComponent<RotateAIM>().enabled = false;
        }
        if (PlayerMovement.isMoving == true)
        {
            VendingUI.gameObject.SetActive(false);
            TargetShoot.GetComponent<ShootingNigger>().enabled = true;
            RotateP.GetComponent<RotateAIM>().enabled = true; ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isplayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isplayer = false;
        }
    }
}
