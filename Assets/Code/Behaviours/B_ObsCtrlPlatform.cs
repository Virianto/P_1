using UnityEngine;

/// <summary>
/// Porque cuando el jugador entre, se activará un botón del canvas para activar
/// el obstáculo.
/// </summary>
public class B_ObsCtrlPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    M_GameManager gameManager;

    [SerializeField]
    B_DynamicObstacle dynamicObstacle;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Intento guardar una referencia al jugador
        B_CharacterController player = other.GetComponent<B_CharacterController>();

        if(player != null)
        {
            gameManager.EnableDynamicObstacleButton(gameObject, dynamicObstacle);
            // Permito que el jugador active el obstáculo
        }
    }

    #endregion
}
