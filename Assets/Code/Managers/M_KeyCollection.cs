using Code.Utils;
using System;
using UnityEngine;

[Flags]
public enum InventoryItems : byte // Al ser un byte podemos trabajar con 8 Flags a la vez: 0000 0000
{
    GreenKey = 1 << 0, // 0000 0001
    RedKey = 1 << 1, // 0000 0010
    BlueKey = 1 << 2 // 0000 0100
}

/// <summary>
/// Mantener un inventario de las llaves recogidas por el jugador
/// * Añadir llaves recogidas
/// * Permitir consultar a otras clases sobre el inventario
/// </summary>
public class M_KeyCollection : Singleton<M_KeyCollection>
{
    #region ATTRIBUTES

    public InventoryItems playerInventory;

    #endregion





    #region METHODS

    #endregion
}