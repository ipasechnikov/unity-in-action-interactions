using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] bool requiredKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (requiredKey && Managers.Inventory.EquippedItem != "key")
            return;

        foreach (var target in targets)
            target.SendMessage("Activate");
    }

    void OnTriggerExit(Collider other)
    {
        foreach (var target in targets)
            target.SendMessage("Deactivate");
    }
}
