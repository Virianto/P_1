using UnityEngine;

/// <summary>
/// Detectar si el jugador ha entrado en su zona
/// Matar al jugador si no tiene la llave correspondiente
/// Desaparecer si tiene la llave correspondiente
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
        B_CoinCharacter player = other.GetComponent<B_CoinCharacter>();
        if(player != null)
        {
            //Comprobar que tenga la llave necesaria y matarle si no la tiene
            if (M_KeyCollection.Instance.playerInventory.HasFlag(requiredKeysToPass))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Has muerto");
            }
        }
    }
    #endregion
}
