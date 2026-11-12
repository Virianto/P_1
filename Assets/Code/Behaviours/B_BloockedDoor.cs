using System;
using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class B_BloockedDoor : MonoBehaviour
{
    #region ATTRIBUTES

    #endregion
    [SerializeField]
    InventoryItems requiredKeysToPass;
    #region METHODS
  void OnTriggerEnter(Collider other)
    {
       B_CharacterController player= other.GetComponent<B_CharacterController>(); 

        if (player != null)
        {
            if (M_Coleccionar.Instance.playerInventory.HasFlag(requiredKeysToPass))
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
