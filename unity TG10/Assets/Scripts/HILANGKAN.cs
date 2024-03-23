using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HILANGKAN : MonoBehaviour
{
    public float durasi;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, durasi);
    }

}
