using Code.Utils;
using System;

[Flags]
public enum InventoryItems : byte
{
    YellowKey = 1 << 0, // 
    GreenKey = 1 << 1 //
}

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_KeyCollection : Singleton<M_KeyCollection>
{
    #region ATTRIBUTES

    public InventoryItems playerInventory;

   #endregion
   #region METHODS
   #endregion    
}

