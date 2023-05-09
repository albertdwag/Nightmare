using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }
}
