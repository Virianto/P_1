using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detcciíon sencilla de cuándo entra un objeto en el trigger
/// Detcciíon sencilla de cuándo sale un objeto en el trigger
/// Lanzamiento de un Unity Event en cada caso
/// </summary>
public class C_SimpleTrigger : MonoBehaviour
{
    #region ATTRIBUTES
    public UnityEvent triggerEnterEvent;

    public UnityEvent triggerExitEvent;
    #endregion


    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        // Lanzar evento de entrada. Preguntar si hay ALGUIEN o ALGO suscrito al evento para q reaccione
        triggerEnterEvent?.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        // Lanzar evento de salida
        triggerExitEvent?.Invoke();
    }
    #endregion
}
