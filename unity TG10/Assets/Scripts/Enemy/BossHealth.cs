using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [SerializeField] float damage;
    [SerializeField] int health;
    [SerializeField] GameObject deadeffect;

    public int currentHealth;
    public BossBar healthbar;
    public bool akukena = false;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        healthbar.setMaxhealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        akukena = true;
        if (currentHealth <= 0)
        {
            Destroy(canvas);
            Instantiate(deadeffect, transform.position, Quaternion.identity);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
