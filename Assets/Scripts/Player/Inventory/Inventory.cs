using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory
{
	
    private List<Item> itemList;

	public Inventory()
	{
		itemList = new List<Item>();
	}

	public void AddItem(Item item)
	{
		itemList.Add(item);
		UIInventoryController.OnItemListChanged.Invoke();
	}

	public void RemoveItem(Item item)
	{
		itemList.Remove(item);
		UIInventoryController.OnItemListChanged.Invoke();
	}

	public List<Item> GetItemList()
	{
		return this.itemList;
	}
}
