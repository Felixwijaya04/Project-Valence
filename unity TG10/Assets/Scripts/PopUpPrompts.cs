using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPrompts : MonoBehaviour
{
    public GameObject prompts;
    private bool _isplayer = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (_isplayer == false)
        {
            prompts.SetActive(false);
        }
        if (_isplayer == true)
        {
            prompts.SetActive(true);
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
