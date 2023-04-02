using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        var posX = 10;
        var posY = 10;
        var width = 100;
        var height = 30;
        var buffer = 10;

        var itemList = Managers.Inventory.GetItemList();
        if (itemList.Count == 0)
            GUI.Box(new Rect(posX, posY, width, height), "No Items");

        foreach (var item in itemList)
        {
            var count = Managers.Inventory.GetItemCount(item);
            var image = Resources.Load<Texture2D>($"Icons/{item}");
            GUI.Box(
                new Rect(posX, posY, width, height),
                new GUIContent($"({count})", image)
            );

            // Shift sideways each time through the loop
            posX += width + buffer;
        }
    }
}
