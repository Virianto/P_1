using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    // Referencia persistente a mi gestor de escena/juego
    public M_GameManager gameManager;

    public GameObject trapGameObject;

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(gameObject, trapGameObject);        
    }

    void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
        // Deshabilito el botón
        // Desvincular la trampa que controla esta plataforma con el OnClick del botón
    }

    #endregion
}
