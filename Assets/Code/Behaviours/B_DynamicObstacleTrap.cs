using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_DynamicObstacleTrap : MonoBehaviour
{

    #region ATTRIBUTES

    bool playerIsInsideArea = false;

    #endregion


    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }

    #endregion
}
