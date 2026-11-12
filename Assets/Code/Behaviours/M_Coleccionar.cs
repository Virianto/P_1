using System;
using Code.Utils;

[Flags]
public enum InventoryItems : byte
{
    YellowKey= 1<< 0,
    BlueKey= 1<< 1,
    TerceraLlave = 1<< 2,
}
// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class M_Coleccionar : Singleton <M_Coleccionar>
{
    #region ATTRIBUTES
    public InventoryItems playerInventory;
    #endregion

    #region METHODS
     
    #endregion
}
