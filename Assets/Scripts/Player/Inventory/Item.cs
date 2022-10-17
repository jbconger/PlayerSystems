using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private ItemType itemType;
    public int amount;

	public Item(ItemType itemType)
	{
		this.itemType = itemType;
		amount = 1;
	}

	public Item(ItemType itemType, int amount)
	{
		this.itemType = itemType;
		this.amount = amount;
	}

	public string GetItemName() { return itemType.GetItemName(); }
	public string GetItemDescription() { return itemType.GetItemDescription(); }
	public int GetItemValue() { return itemType.GetItemValue(); }
	public Sprite GetSprite() { return itemType.GetSprite(); }
	public bool GetStackable() { return itemType.GetStackable(); }
}
