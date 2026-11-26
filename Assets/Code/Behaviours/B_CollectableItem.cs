using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_CollectableItem : MonoBehaviour
{

    #region ATTRIBUTES

   
   public SO_InventoryItemConfig inventoryItemConfig;

    #endregion


    #region METHODS


    void OnTriggerEnter(Collider other)
    {
      B_CoinCharacter player = other.GetComponent<B_CoinCharacter>();
        if(player != null)
        {
            UI_CollectionCanvas.Instance.ModifySingleItemPanel(inventoryItemConfig.configData);
        }
    }
    #endregion
}
