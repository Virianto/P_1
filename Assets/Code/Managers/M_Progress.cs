
using Code.Utils;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Lleva la cuenta de objetos recogidos por el jugador
/// </summary>
public class M_Progress : Singleton<M_Progress>
{

    #region ATTRIBUTES

    List<SO_InventoryItemConfig> allCollectedItemsList = new();

    #endregion



    #region METHODS

    public void NewItemCollected(SO_InventoryItemConfig item)
    {
        allCollectedItemsList.Add(item);
    }

    #endregion
}