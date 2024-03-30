using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Animator animator;
    public BossScript Val;
    private void OnEnable()
    {
        if (Val.attack == true)
        {
            GetComponent<BossScript>().enabled = false;
            animator.SetTrigger("Attack");
            Val.attack = false;
            After();
        }

    }


    void After()
    {
        if(Val.attack == false)
        {
            GetComponent<BossScript>().enabled = true; 
            GetComponent<BossAttack>().enabled = false;
        }
    }
}


