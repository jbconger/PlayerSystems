using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private Inventory playerInventory;

	private void Awake()
	{
		playerInventory = new Inventory();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		ItemPickUp itemPickUp = collision.GetComponent<ItemPickUp>();

		if (itemPickUp != null)
		{
			playerInventory.AddItem(itemPickUp.GetItem());
			itemPickUp.DestroySelf();
		}
	}

	public Inventory GetInventory()
	{
		return playerInventory;
	}
}
