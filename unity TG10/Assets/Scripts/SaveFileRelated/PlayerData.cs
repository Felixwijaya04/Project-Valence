using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] Position;
    public int health;
    public int armor;

    public PlayerData(PlayerMovement pm)
    {
        health = pm.currentHealth;
        armor = pm.currentarmor;
        Position = new float[3];

        Position[0] = pm.transform.position.x;
        Position[1] = pm.transform.position.y;
        Position[2] = pm.transform.position.z;
    }

}
