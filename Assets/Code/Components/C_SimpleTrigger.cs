using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// * Detección sencilla de cuando entra un objeto en el trigger
/// * Detección sencilla de cuando sale un objeto del trigger
/// * Lanzamiento de un UnityEvent en cada uno de los casos
/// </summary>
public class C_SimpleTrigger : MonoBehaviour
{

    #region ATTRIBUTES

    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    #endregion



    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        // Lanzar evento de entrada
        // Preguntar si hay alguien o algo suscrito al evento para que reaccione

        triggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        // Lanzar evento de salida

        triggerExitEvent?.Invoke();
    }

    #endregion
}