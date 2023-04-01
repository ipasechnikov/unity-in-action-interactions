using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    private IDictionary<string, int> items;

    public ManagerStatus Status
    {
        get; private set;
    }

    public void Startup()
    {
        Debug.Log("Invetory manager starting...");
        items = new Dictionary<string, int>();
        Status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        var sb = new StringBuilder();
        sb.Append("Items: ");
        foreach (var kv in items)
        {
            var itemName = kv.Key;
            var itemCount = kv.Value;
            sb.Append($"{itemName} ({itemCount}) ");
        }
        Debug.Log(sb.ToString());
    }

    public void AddItem(string name)
    {
        if (!items.TryGetValue(name, out var count))
            count = 0;
        items[name] = count + 1;
        DisplayItems();
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
