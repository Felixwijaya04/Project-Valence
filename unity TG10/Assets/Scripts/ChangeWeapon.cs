using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public bool isRifle = false;
    public Animator animator;
    public ShootingNigger weapon;
    public BulletDamage bullet;
    public int tempdeagle = 7;
    public int temprifle = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isRifle == false)
        {
            isRifle = true;
            Debug.Log("Changing");
            animator.SetTrigger("Change");
            weapon.ammo = 20;
            tempdeagle = weapon.currentammo;
            weapon.currentammo = temprifle;
            weapon.intervalFiring = 0.15f;
            bullet.damage = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isRifle == true)
        {
            isRifle = false;
            Debug.Log("Changing");
            animator.SetTrigger("Changee");
            weapon.ammo = 7;
            temprifle = weapon.currentammo;
            weapon.currentammo = tempdeagle;
            weapon.intervalFiring = 0.8f;
            bullet.damage = 20;
        }
    }
}
