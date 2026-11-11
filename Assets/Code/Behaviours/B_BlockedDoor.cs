using UnityEngine;

/// <summary>
/// Detectar si el jugador a entrado en la zona y
/// Matar al jugador si NO tiene la llave correspondiente
/// Desaparecer si el jugador SI tiene la llave correspondiente
/// </summary>
public class B_BlockedDoor : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    InventoryItems requiredKeyToPass;

    #endregion


    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        //Si el q intenta pasar es el jugador
        if(player != null)
        {
            // Comprobar q tenga la llave y matarle si no la tiene
            if(M_KeyCollectionManager.Instance.playerInventory.HasFlag(requiredKeyToPass))
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
