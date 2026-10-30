using UnityEngine;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_obstacleplatform : MonoBehaviour
{
    #region ATTRIBUTES



    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if (player != null )
        {
            //gameManager.EnableDynamicObstacleButton();
        }

    }

    #endregion
}

