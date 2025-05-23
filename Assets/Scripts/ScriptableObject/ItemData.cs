using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    consumable,
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

    // 델리게이트(액션) 추가
    [NonSerialized] public Action<ItemObject> onInteractAction;
}
