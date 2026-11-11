using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
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
            M_KeyCollection.Instance.playerInventory |= thisItem;
            UI_InventoryCanvas.Instance.AddNewInventoryItem(thisItem);
            gameObject.SetActive(false);
        }
    }

    #endregion
}

