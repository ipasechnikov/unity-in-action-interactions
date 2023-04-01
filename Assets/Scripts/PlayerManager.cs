using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status
    {
        get; private set;
    }

    public int Health
    {
        get; private set;
    }

    public int MaxHealth
    {
        get; private set;
    }

    public void Startup()
    {
        Debug.Log("Player manager is starting...");

        Health = 50;
        MaxHealth = 100;

        Status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value)
    {
        Health += value;
        if (Health > MaxHealth)
            Health = MaxHealth;
        else if (Health < 0)
            Health = 0;

        Debug.Log($"Health: {Health}/{MaxHealth}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
