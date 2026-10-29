using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    //detectar cuando ha entrado un jugador
    //habilitar el boton para desactivar la trampa
    //vincular la trampa que controla la plataforma con el OnClick del boton

    //detectar cuando ha salido el jugador
    // deshabillitar boton
    //desvincular la trampa que controla la plataforma con el OnClick del boton
    #region ATTRIBUTES
    public M_GameManager gameManager;
    public GameObject trapGameObject;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(gameObject, trapGameObject);
        // Habilitar el botón para desactivar trampa
        // Vincular la trampa que controla esta plataforma con el OnClick del botón
    }

    void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
        // Deshabilito el botón
        // Desvincular la trampa que controla esta plataforma con el OnClick del botón
    }
    #endregion
}
