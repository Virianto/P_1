using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// * Lanzamiento de un UnityEvent en cada uno de los casos
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
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
        triggerEnterEvent?.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
        triggerExitEvent?.Invoke();
    }

    #endregion
}