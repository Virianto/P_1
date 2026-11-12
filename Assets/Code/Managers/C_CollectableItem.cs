using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class C_CollectableItem : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    InventoryItems thisItem;
    #endregion

    #region METHODS

    #endregion
    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();
        if (player != null )
        {
            M_Coleccionar.Instance.playerInventory |= thisItem;

            gameObject.SetActive(false);
        }
    }
}
