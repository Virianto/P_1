using UnityEngine;

/// <summary>
/// * Notificar recolección (lanzar un evento con los datos del objeto)
/// </summary>
public class B_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES
        
    public SO_InventoryItemConfig inventoryItemConfig;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Busco el componente de jugador en el objeto que he detectado
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si, efectivamente, se trata del jugador porque tiene ese componente...
        if(player != null)
        {
            UI_Collection.Instance.ModifySingleItemPanel(inventoryItemConfig.configData);
        }
    }

    #endregion
}
