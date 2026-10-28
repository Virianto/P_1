using UnityEngine;


/// <summary>
/// Una plataforma que activa un botón del Canvas para que, al pulsarlo, la puerta se active
/// </summary>
public class B_ActivateDoor : MonoBehaviour
{
    #region ATTRIBUTES

    // Referencia a mi gestor de juego
    public M_GameManager gameManager;
    public GameObject doorGameObject;

    #endregion





    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableDynamicDoorButton(gameObject, doorGameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableDynamicDoorButton();
    }

    #endregion
}