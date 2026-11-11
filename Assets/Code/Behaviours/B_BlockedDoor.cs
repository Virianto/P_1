using UnityEngine;


/// <summary>
/// * Detectar si el jugador ha entrado en su zona
/// * Matar al jugador si no tiene la llave correspondiente
/// * 
/// </summary>
public class B_BlockedDoor : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    InventoryItems requiredKeysToPass;

    #endregion





    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        // Si el que intenta pasar es el jugador...
        if (player != null)
        {
            // Comprobar que tenga la llave correspondiente
            // Si la tiene...
            if (M_KeyCollection.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                // Abrimos la puerta
                gameObject.SetActive(false);
            }
            // Si no la tiene...
            else
            {
                player.TakeDamage(999);
            }
        }
    }

    #endregion
}