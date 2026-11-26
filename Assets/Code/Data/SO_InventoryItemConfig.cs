using System;
using UnityEngine;

/// <summary>
/// Me permite crear una representación serializada de una clase en el editor
/// </summary>
[CreateAssetMenu(
    fileName = "SingleItemConfig", 
    menuName = "Scriptable Objects/SingleItem",
    order = 2)]
public class SO_InventoryItemConfig : ScriptableObject
{
    public D_SingleInventoryItem configData; 
}

[Serializable]
public struct D_SingleInventoryItem
{
    public GameObject itemPrefab;

    public string itemName;

    public Sprite itemIcon;

    public float itemValue;
}
