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
            // Busco al M_KeyCollection y le añado thisItem a su inventario
            M_KeyCollection.Instance.playerInventory |= thisItem;

            // Llave azul -> 0000 0010
            // 0000 0000
            // ???? ??1?

            // Desaparezco
            gameObject.SetActive(false);
        }
    }

    #endregion
}
