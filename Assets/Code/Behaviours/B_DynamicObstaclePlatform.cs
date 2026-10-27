using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_DynamicObstaclePlatform : MonoBehaviour
{

    #region ATTRIBUTES

    public M_GameManager gameManager;

    public GameObject trapGameObject;

    #endregion


    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        //Habilitar el botón para desactivar trampa
        gameManager.EnableObstacleTrapButton(gameObject, trapGameObject);
        //Vincular la trampa que controla esta platafrma con el OnClick del botón


    }


    private void OnTriggerExit(Collider other)
    {
        //    //Deshabilito el botón
        gameManager.DisableObstacleTrapButton();
        //Desvincular la trampa que controla esta platafrma con el OnClick del botón 
    }

    #endregion
}
