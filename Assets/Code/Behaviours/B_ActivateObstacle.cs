using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_ActivateObstacle : MonoBehaviour
{
    #region ATTRIBUTES

    // Referencia a mi gestor de juego
    public M_GameManager gameManager;
    public GameObject trapGameObject;

    #endregion





    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(gameObject, trapGameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }

    #endregion
}