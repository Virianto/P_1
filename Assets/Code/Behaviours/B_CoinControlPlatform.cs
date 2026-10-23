using UnityEngine;

public class B_CoinControlPlatform : MonoBehaviour
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
        gameManager.EnableCoinTrapButton(gameObject, trapGameObject);
        //Vincular la trampa que controla esta platafrma con el OnClick del botón
        

    }
    

    private void OnTriggerExit(Collider other)
    {
        //    //Deshabilito el botón
        gameManager.DisableCoinTrapButton();
        //Desvincular la trampa que controla esta platafrma con el OnClick del botón 
    }


    #endregion
}
