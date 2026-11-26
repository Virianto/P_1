using System;
using UnityEngine;

// PRIMER BLOQUE - Scriptable Object

/// <summary>
/// Me permite crear una representación serializada de una clase en el editor de Unity
/// </summary>
[CreateAssetMenu(fileName = "SingleItemConfig", menuName = "Scriptable Objects/SingleItem", order = 2)]
public class SO_InventoryItemConfig : ScriptableObject
{
    public D_SingleInventoryItem configData;
}

// SEGUNDO BLOQUE - Enumerado público


// TERCER BLOQUE - Estructura de datos

[Serializable]
public struct D_SingleInventoryItem
{
    public string itemName;
    public Sprite itemIcon;
    public float itemValue;

    public GameObject itemPrefab;
}
