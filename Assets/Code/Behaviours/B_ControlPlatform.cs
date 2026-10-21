using UnityEngine;

public class B_ControllPatform : MonoBehaviour
{
    #region ATTRIBUTES
    // Referencia a mi gestor de juego
    public M_GameManager gameManager;
    public GameObject trapGameObject;

    #endregion




    #region METHODS

    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton(trapGameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }


    #endregion
}
