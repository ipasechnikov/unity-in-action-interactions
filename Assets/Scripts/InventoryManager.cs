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

    public string EquippedItem
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

    public List<string> GetItemList()
    {
        return new List<string>(items.Keys);
    }

    public int GetItemCount(string name)
    {
        items.TryGetValue(name, out var count);
        return count;        
    }

    public bool EquipItem(string name)
    {
        if (items.ContainsKey(name) && EquippedItem != name)
        {
            EquippedItem = name;
            Debug.Log($"Equipped {name}");
            return true;
        }

        EquippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }

    public bool ConsumeItem(string name)
    {
        if (!items.TryGetValue(name, out var count))
        {
            Debug.Log($"Cannot consume {name}");
            return false;
        }

        count--;
        if (count == 0)
            items.Remove(name);
        else
            items[name] = count;

        DisplayItems();
        return true;

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
