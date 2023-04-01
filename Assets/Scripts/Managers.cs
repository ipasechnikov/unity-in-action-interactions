using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player
    {
        get; private set;
    }

    public static InventoryManager Inventory
    {
        get; private set;
    }

    private List<IGameManager> startSequence;

    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (var manager in startSequence)
            manager.Startup();

        yield return null;

        var numModules = startSequence.Count;
        var numReady = 0;

        while (numReady < numModules)
        {
            var lastReady = numReady;
            numReady = 0;

            foreach (var manager in startSequence)
                if (manager.Status == ManagerStatus.Started)
                    numReady++;

            if (numReady > lastReady)
                Debug.Log($"Progress: {numReady}/{numModules}");

            // Pause for one frame before checking again
            yield return null;
        }

        Debug.Log("All managers started up");
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
