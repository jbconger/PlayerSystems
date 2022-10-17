using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemSetUp : MonoBehaviour
{
    [SerializeField] private List<ItemType> itemTypes;
    [SerializeField] private List<Vector3> itemSpawnLocations;

    void Start()
    {
        for(int i = 0; i < itemTypes.Count; i++)
		{
            ItemPickUp.SpawnItemPickUp(itemSpawnLocations[i], new Item(itemTypes[i]));
		}
    }

}
