using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{


    #region ATTRIBUTES

    // Referencia persistente a mi gestor de escerna/juego
    public M_GameManager gameManager;

    public GameObject trapGameObject;




    #endregion



    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton();
        // Detectar cuando ha entrado el jugador
        // Habilitar el botón para desactivar trampa
        // Vincular la trampa que controla esta plataforma con el OnClick del botón   
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
