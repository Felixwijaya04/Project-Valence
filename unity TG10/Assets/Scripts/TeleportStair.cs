using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStair : MonoBehaviour
{
    // Coding pilip (katnaya pake gameevent)
    // public Transform Destination2;
    // public Transform Destination;
    // private Transform destination{
    //     public get{
    //         return destination;
    //     }
    //     set{
    //         destination = Destination;
    //     }
    // }
    // public KeyCode key;
    // private Transform destination2{
    //     public get{
    //         return destination;
    //     }
    //     set{
    //         return Destination2;
    //     }
    // }
    // public KeyCode key2;

    [SerializeField] private Transform destinationup;
    [SerializeField] private Transform destinationdown;

    public Transform GetDestinationUp()
    {
        return destinationup;
    }

    public Transform GetDestinationDown()
    {
        return destinationdown;
    }
}
