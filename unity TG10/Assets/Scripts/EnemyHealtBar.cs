using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyHealtBar : MonoBehaviour
{
    public GameObject EnemyHealtbar;
    public Vector3 Offset;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        EnemyHealtbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
