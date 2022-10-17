using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIInventoryController : MonoBehaviour
{
	public static UnityEvent OnItemListChanged;

	[SerializeField] private PlayerInventory playerInventory;

	private Inventory inventory;
	private Transform itemSlotContainer;
	private Transform itemSlotTemplate;

	private void Awake()
	{
		itemSlotContainer = transform.Find("ItemSlotContainer");
		itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");

		if (OnItemListChanged == null)
			OnItemListChanged = new UnityEvent();
	}

	private void Start()
	{
		SetInventory(playerInventory.GetInventory());
	}

	public void SetInventory(Inventory inventory)
	{
		this.inventory = inventory;

		OnItemListChanged.AddListener(RefreshInventoryItems);
		RefreshInventoryItems();
	}

	public void DropItem(Vector3 dropPosition, Item item)
	{
		playerInventory.RemoveItem(item);
		ItemPickUp.DropItem(dropPosition, item);
	}

	private void RefreshInventoryItems()
	{
		// clear inventory
		foreach (Transform child in itemSlotContainer)
		{
			if (child == itemSlotTemplate)
				continue;
			Destroy(child.gameObject);
		}

		int x = 0, y = 0;
		float itemSlotCellSize = 60f;

		foreach(Item item in inventory.GetItemList())
		{
			// place item
			RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
			itemSlotRectTransform.gameObject.SetActive(true);
			itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

			//itemSlotRectTransform.GetComponent<OnClick>().OnLeftClick.AddListener();
			itemSlotRectTransform.GetComponent<OnClick>().OnRightClick.AddListener( () => { DropItem(playerInventory.gameObject.transform.position, item); });

			//update image
			Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
			image.sprite = item.GetSprite();

			x++;

			if (x > 3)
			{
				x = 0;
				y++;
			}
		}
	}
}
