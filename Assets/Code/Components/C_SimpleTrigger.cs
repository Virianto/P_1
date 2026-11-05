using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// * Detección de cuándo entra un objeto en el Trigger
/// * Detección de cuándo sale un objeto del Trigger
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
        // Lanzar Evento de entrada

        // Preguntar si hay alguien o algo suscrito al evento para que reaccione
        triggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        // Lanzar Evento de salida

        // Preguntar si hay alguien o algo suscrito al evento para que reaccione
        triggerExitEvent?.Invoke();
    }

    #endregion
}