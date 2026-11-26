using UnityEngine;

/// <summary>
/// Detectar que ha tocado jugador
/// Notificar recolleción (lanza un evento con los datos del objeto)
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

        if (player != null)
        {
            //Lanzo evento de "Objeto recolectado"
            UI_CollectionCanvas.Instance.ModifySinglePanel(inventoryItemConfig.configData);
            M_Progress.Instance.NewItemCollected(inventoryItemConfig);
        }
    }

    #endregion
}
