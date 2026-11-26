using UnityEngine;

/// <summary>
/// Detectar que me ha tocado el jugador
/// Notificar al manager
/// </summary>
public class B_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES
    public SO_InventoryItemConfig inventoryItemConfig;


    #endregion


    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        // Busco el componente de jugador en el objeto q he detectado
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si, efectivamente, se trata del jugagor porque tiene ese componente
        if (player != null )
        {
            // Lanzo un evento de "Objeto recolectado"
            // Aquí podría ir la invocación del método q lance partículas, sonido, etc
            UI_CollectionCanvas.Instance.ModifySingleItemPanel(inventoryItemConfig.configData);

            M_Progress.Instance.NewItemCollected(inventoryItemConfig);
        }
    }

    #endregion
}
