using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemType", menuName = "ItemType")]
public class ItemType : ScriptableObject
{
	public string itemName;
	public string description;
	public int value;
	

	public Sprite sprite;
	public bool isStackable;
	public bool isConsumable;
	public Color colorEffect;

	public string GetItemName()	{ return itemName; }
	public string GetItemDescription() { return description; }
	public int GetItemValue() { return value; }
	public Sprite GetSprite() { return sprite; }
	public bool GetStackable() { return isStackable; }
	public bool GetConsumable() { return isConsumable; }
	public Color GetColor() { return colorEffect; }
}
