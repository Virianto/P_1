using UnityEngine;

/// <summary>
/// * Detectar que me ha tocado el jugador
/// * Notificar recolección (lanzarun evento con los datos del objeto)
/// </summary>
public class B_CollectableItem : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    public SO_InventoryItemConfig inventoryItemConfig;

    #endregion



    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        // Busco el componente de jugador en el objeto que he detectado
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si se trata del jugador porque tiene ese componente
        if(player != null)
        {
            // Lanzo un evento de "ObjetoRecolectado"
            // Aquí podría ir la invocación al método que lance partículas, sonido, etc. a través del manager
            UI_CollectionCanvas.Instance.ModifySingleItemPanel(inventoryItemConfig.configData);
        }
    }

    #endregion
}