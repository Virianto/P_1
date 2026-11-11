using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_BlockedDoor : MonoBehaviour
{
    #region ATTRIBUTES
    #endregion
    #region METHODS

    [SerializeField]
    InventoryItems requiredKeysToPass;

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if (player != null)
        {
            if (M_KeyCollection.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                gameObject.SetActive(false);
            }
            else
            {
                player.TakeDamage(999);
            }

        }
    }

    #endregion
}

