using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    healItem,
    jumpItem,
    resourceItem,
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public string itemDescription;
    public ItemType itemType;
    public GameObject itemPrefab;

    [Header("Item Stacking")]

    public bool canStack;
    public int maxStackAmount;
}
