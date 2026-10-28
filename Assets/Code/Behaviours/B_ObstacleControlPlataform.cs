using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_ObstacleControlPlataform : MonoBehaviour
{
    #region ATTRIBUTES

    // Referencia a mi Game Manager
    public M_GameManager gameManager;

    [SerializeField]
    B_Dynamic_Obstacle dynamicObstacle;

    #endregion


    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        // Intento guardar una referencia al jugador
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if (player != null)
        {
            // No hago nada si es null pero si es diferente:
            // Permito q el jugador active el obstáculo
            gameManager.EnableDynamicObstacleButton(gameObject, dynamicObstacle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }

    #endregion
}
