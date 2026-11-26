using UnityEngine;

/// <summary>
/// texto de prueba
/// </summary>
public class FM_COLLLECTABLEOBJECT : MonoBehaviour
{
    #region ATTRIBUTES
    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();
        if (player != null)
        {


        }
    }
    #endregion
}
