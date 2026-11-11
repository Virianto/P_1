using UnityEngine;


/// <summary>
/// Detectar al jugador cuando toque el objeto
/// * Añadir a inventario de juego un elemento específico
/// * Desaparecer
/// </summary>
public class C_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    InventoryItems thisItem;

    #endregion





    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if (player != null)
        {
            // Busco al Manager y le añado este objeto a su inventario
            M_KeyCollection.Instance.playerInventory |= thisItem;

            UI_InventoryCanvas.Instance.AddNewInventoryItem(thisItem);

            // Desaparezco
            gameObject.SetActive(false);
        }
    }

    #endregion
}