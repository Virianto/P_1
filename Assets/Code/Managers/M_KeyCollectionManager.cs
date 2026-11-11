using Code.Utils;
using System;

/// <summary>
/// Como es un byte, vamos a poder trabajar con 8 flags a la vez: 0000 0000
/// </summary>
[Flags]
public enum InventoryItems: byte // No podrá recoger más allá de 7 cosas, de normal no se ponde nada
{
    YellowKey = 1 << 0,     // 0000 0001
    PinkKey = 1 << 1,       // 0000 0010
    EjemploKey = 1 << 2  // 0000 0100
}

/// <summary>
/// * Mantener un inventario de las llaver recogidas por el jugador
///  -> Añadir llaves recogidas
///  -> Permitir consulta a otras clases sobre el inventario
/// </summary>
public class M_KeyCollectionManager : Singleton<M_KeyCollectionManager>
{
    #region ATTRIBUTES
    public InventoryItems playerInventory;

    #endregion


    #region METHODS
   

    #endregion
}
