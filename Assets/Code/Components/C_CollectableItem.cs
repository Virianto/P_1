using UnityEngine;

/// <summary>
/// Detectar al jugador cuando pase
/// -> Desaparecer
/// -> Añadir al inventario de juego un elemento específico
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
     B_CoinCharacter player = other.GetComponent<B_CoinCharacter>();
        if (player != null)
        {
            M_KeyCollection.Instance.playerInventory |= thisItem;
            UI_InventoryCanvas.Instance.AddNewInventoryItem(thisItem);
            gameObject.SetActive(false);
        }
    }

    #endregion
}
