using UnityEngine;

/// <summary>
/// * Detectar al jugador cuando pase y...
///  -> Añadir al inventario de juego un elemento específico
///  -> Desaparecer
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

        if(player != null)
        {
            // Pongo el bit del objeto correspondiente a 1 (SIEMPRE)
            M_KeyCollection.Instance.playerInventory |= thisItem;

            UI_InventoryCanvas.Instance.AddNewInventoryItem(thisItem);

            // Hago desaparecer el objeto
            gameObject.SetActive(false);
        }
    }

    #endregion
}
