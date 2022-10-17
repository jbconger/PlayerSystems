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

	public static ItemPickUp DropItem(Vector3 dropPosition, Item item)
	{
		Vector3 randomDirection = Random.insideUnitCircle.normalized;
		ItemPickUp itemPickUp = SpawnItemPickUp(dropPosition + randomDirection * 1.5f, item);
		itemPickUp.GetComponent<Rigidbody2D>().AddForce(randomDirection * 1.5f, ForceMode2D.Impulse);

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
