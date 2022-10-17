using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : ScriptableObject
{
	public string itemName;
	public string description;
	public int value;

	public Sprite sprite;
	public bool isStackable;
}
