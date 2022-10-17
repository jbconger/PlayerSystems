using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
	public static ItemPickUp SpawnItemPickUp(Vector3 position, Item item)
	{
		GameObject gameObject = Instantiate(Resources.Load("PF_ItemPickUp") as GameObject, position, Quaternion.identity);

		ItemPickUp itemPickUp = gameObject.GetComponent<ItemPickUp>();
		itemPickUp.SetItem(item);

		return itemPickUp;
	}

    private Item item;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetItem(Item item)
	{
		this.item = item;
		spriteRenderer.sprite = item.GetSprite();
	}

	public Item GetItem()
	{
		return item;
	}

	public void DestroySelf()
	{
		Destroy(gameObject);
	}
}
