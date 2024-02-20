using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float range;
    public bool isDoorOpen = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    public float _doorSpeed = 50f;

    // Start is called before the first frame update
    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, transform.position.y - 35f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        

        // if (isDoorOpen)
        // {
        //     OpenDoor();
        // } else if (!isDoorOpen)
        // {
        //     CloseDoor();
        // }

        if (distance < range)
        {
            OpenDoor();
        } else if (distance > range)
        {
            CloseDoor();
        }
    }


    public void OpenDoor()
    {
        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, _doorSpeed * Time.deltaTime);
        }
    }

    public void CloseDoor()
    {
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, _doorSpeed * Time.deltaTime);
        }
    }
}
