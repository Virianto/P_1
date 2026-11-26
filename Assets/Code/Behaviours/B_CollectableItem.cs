using UnityEngine;


/// <summary>
/// * Detectar que me ha tocado el jugador
/// * Notificar recolección (lanzar un evento con los datos del objeto)
/// </summary>
public class B_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES

    public SO_InventoryItemConfig inventoryItemConfig;

    #endregion





    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si se trata del jugador...
        if (player != null)
        {
            // Lanzo un evento de "ObjetoRecolectado"
            UI_Collection.Instance.ModifySingleItemPanel(inventoryItemConfig.configData);

            M_Progress.Instance.NewItemCollected(inventoryItemConfig);
        }
    }

    #endregion
}