using Unity.VisualScripting;
using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    //Referencia persistente a mi gestor de escena/juego
    public M_GameManager gameManager;

    public GameObject trapGameObject;


    #endregion

    #region METHODS
    
    private void OnTriggerEnter(Collider other)
    {
        //Habilitar el botón para desactivar trampa
        gameManager.EnableTrapButton(trapGameObject);
        //Vincular la trampa que controla esta platafrma con el OnClick del botón  
        
    }


    private void OnTriggerExit(Collider other)
    {
        //Deshabilito el botón
        gameManager.DisableTrapButton();
        //Desvincular la trampa que controla esta platafrma con el OnClick del botón 
    }
    

    #endregion
}
