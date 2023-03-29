using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    // Amount to offset the position by when the door opens
    [SerializeField] Vector3 dPos;

    // Keep track of the open state of the door
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        if (open)
        {
            var pos = transform.position - dPos;
            transform.position = pos;
        }
        else
        {
            var pos = transform.position + dPos;
            transform.position = pos;

        }
        open = !open;
    }

    public void Activate()
    {
        if (!open)
        {
            var pos = transform.position + dPos;
            transform.position = pos;
            open = true;
        }
    }

    public void Deactivate()
    {
        if (open)
        {
            var pos = transform.position - dPos;
            transform.position = pos;
            open = false;
        }
    }
}
