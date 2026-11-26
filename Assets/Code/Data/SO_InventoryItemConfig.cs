using UnityEngine;
using System;


/// <summary>
/// Permite crear una representación serializada de una clase en el editor de Unity
/// </summary>
[CreateAssetMenu(fileName = "SingleItemConfig", menuName = "ScriptableObjects / SingleItem", order = 2)]
public class SO_InventoryItemConfig : ScriptableObject
{
    public D_SingleInventoryItem configData;
}

[Serializable]
public struct D_SingleInventoryItem
{
    public string itemName;
    public Sprite itemIcon;
    public float itemValue;
    public GameObject itemPrefab;
}