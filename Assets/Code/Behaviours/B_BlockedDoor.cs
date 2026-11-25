using UnityEngine;

/// <summary>
/// * Detectar si el jugador ha entrado en su zona y...
/// * Matar al jugador si no tiene la llave correspondiente
/// * Desaparecer si el jugador tiene la llave correspondiente
/// </summary>
public class B_BlockedDoor : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    InventoryItems requiredKeysToPass;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si el que intenta pasar es el jugador...
        if(player != null)
        {
            // Comprobar que tenga la llave necesaria y matarle si no la tiene
            if (M_KeyCollection.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                // "Abro" la puerta
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
