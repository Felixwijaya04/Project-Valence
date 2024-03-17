using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VendingManager : MonoBehaviour
{
    public GameObject VendingUI;
    public Behaviour playerscript;
    public GameObject RotateP;
    public GameObject TargetShoot;
    public CinemachineVirtualCamera Camera;
    public float zoomingin;
    public float zoomingout;
    public float velocity = 0f;
    private bool openvending;

    private bool _isplayer = false;
    private float smoothTime = 0.25f;

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
            openvending = true;
            VendingUI.gameObject.SetActive(true);
            //disabled player movement when shop ui is open
            /*playerscript.enabled = false;*/
            TargetShoot.GetComponent<ShootingNigger>().enabled = false;
            RotateP.GetComponent<RotateAIM>().enabled = false;
            /*Camera.m_Lens.OrthographicSize = zoomingin;*/
            

        }
        if (PlayerMovement.isMoving == true)
        {
            openvending = false;
            VendingUI.gameObject.SetActive(false);
            TargetShoot.GetComponent<ShootingNigger>().enabled = true;
            RotateP.GetComponent<RotateAIM>().enabled = true; ;
            /*Camera.m_Lens.OrthographicSize = zoomingout;*/
            /*Camera.m_Lens.OrthographicSize = Mathf.Lerp(Camera.m_Lens.OrthographicSize, zoomingout, smoothTime);*/
        }
        if(openvending == true)
        {
            Camera.m_Lens.OrthographicSize = Mathf.SmoothDamp(Camera.m_Lens.OrthographicSize, zoomingin, ref velocity, smoothTime);
        }
        else
        {
            Camera.m_Lens.OrthographicSize = Mathf.SmoothDamp(Camera.m_Lens.OrthographicSize, zoomingout, ref velocity, smoothTime);
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
