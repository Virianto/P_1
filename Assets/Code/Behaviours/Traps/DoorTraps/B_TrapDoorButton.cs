using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_TrapDoorButton : MonoBehaviour
{
#region ATTRIBUTES
    public M_GameManager gameManager;
    public B_TrapDoor trapDoorObject;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.EnableTrapDoor(gameObject, trapDoorObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.DisableTrapButton();
        }
    }

    #endregion
}
