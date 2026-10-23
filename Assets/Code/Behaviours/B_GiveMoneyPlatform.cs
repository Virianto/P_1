using UnityEngine;
using UnityEngine.SceneManagement;

public class B_GiveMoneyPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    // Referencia persistente a mi gestor de escerna/juego
    public M_GameManager gameManager;

    public GameObject trapGameObject;



    #endregion

    #region METHODS


    // Detectar cuando ha entrado el jugador
    void OnTriggerEnter(Collider other)
    {

        // Habilitar el botón para desactivar trampa
        // Vincular la trampa que controla esta plataforma con el OnClick del botón
        gameManager.EnableTrapButton(gameObject, trapGameObject);


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
