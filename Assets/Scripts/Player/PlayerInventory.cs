using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private Inventory playerInventory;
	private SpriteRenderer sprite;

	private void Awake()
	{
		playerInventory = new Inventory();
		sprite = GetComponent<SpriteRenderer>();
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

	public void AddItem(Item item)
	{
		playerInventory.AddItem(item);
	}

	public void RemoveItem(Item item)
	{
		playerInventory.RemoveItem(item);
	}

	public void UseItem(Item item)
	{
		if (item.GetConsumable())
		{
			Color flashColor = item.GetColor();

			StartCoroutine(FlashColor(flashColor));

			playerInventory.RemoveItem(item);
		}
	}

	private IEnumerator FlashColor(Color color)
	{
		for (int i = 0; i < 3; i++)
		{
			sprite.material.color = Color.white;
			yield return new WaitForSeconds(.1f);
			sprite.material.color = color;
			yield return new WaitForSeconds(.1f);
		}

		sprite.material.color = Color.white;
	}
}
