using UnityEngine;

/// <summary>
/// Va a tener una referencia a un obstáculo y se va a encargar de detectar cuándo ha entrado el jugador en su área de efecto.
/// Porque cuando el jugador entre, se activará un botón del canvas para activar el obstaculo.
/// </summary>
public class B_ActivateDynamicObjectPlatform : MonoBehaviour
{

    #region ATTRIBUTES

    // Referencia persistente a mi gestor de escerna/juego
    public M_GameManager gameManager;

    public B_DynamicObstacle dynamicObstacle;

    #endregion



    #region METHODS

    // Detectar cuando ha entrado el jugador
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



    void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
        // Detectar cuando ha salido el jugador
        // Deshabilito el botón
        // Desvincular la trampa que controla esta plataforma con el OnClick del botón
    }

    #endregion
}