using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    #region ATTRIBUTES
    // Referencia a mi Game Manager
    public M_GameManager gameManager;

    public GameObject trapGameObject;

    #endregion


    #region METHODS

    // Detectar cuando ha entrado el jugador
    // Habilitar el botón para desactivar trampa
    // Vincular la trampa q controla esta plataforma con el OnClick del botón
    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(trapGameObject);
    }

    // Detectar cuando ha salido el jugador
    // Deshabilito el botón
    // Desvincular la trampa q controla esta plataforma con el OnClick del botón
    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }

    #endregion
}
