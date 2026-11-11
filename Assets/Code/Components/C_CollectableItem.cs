using UnityEngine;

/// <summary>
/// Detectar al jugador cuando pase
/// Desaparecer
/// Añadir al inventario de juego 1 elemento específico
/// </summary>
public class C_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    InventoryItems thisItem;

    #endregion


    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if(player != null )
        {
            // Busco M_KeyCollection y le añado thisItem a su inventario
            M_KeyCollectionManager.Instance.playerInventory |= thisItem;

            UI_InventoryCanvas.Instance.AddNewInventoryItem(thisItem);

            // Desaparezco
            gameObject.SetActive(false);
        }
    }

    #endregion
}
