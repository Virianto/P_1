using Code.Utils;
using System;

/// <summary>
/// Como es un byte, vamos a poder trabajar con 8 flags a la vez: 0000 0000
/// </summary>
[Flags]
public enum InventoryItems : byte
{
    YellowKey = 1 << 0,     // 0000 0001
    BlueKey = 1 << 1,       // 0000 0010
    TerceraLlave = 1 << 2   // 0000 0100                            
}

/// <summary>
/// * Mantener un inventario de las llaves recogidas por el jugador
///     -> Añadir llaves recogidas
///     -> Permitir consulta a otras clases sobre el inventario
/// </summary>
public class M_KeyCollection : Singleton<M_KeyCollection>
{
    #region ATTRIBUTES

    public InventoryItems playerInventory;

    #endregion

    #region METHODS



    #endregion
}
