using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// *Detectar cuando un objeto entra en el trigger
/// *Detectar cuando un objeto sale del trigger
/// *Lanzamiento de un UnityEvent en cada uno de los casos
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
        // preguntar si hay alguien o algo suscrito al evento para que reaccione.
        triggerEnterEvent?.Invoke(); //? -> interrogante flexible, viene a ser si hay algo ahi, continua con esto, como un if creo

    }

    void OnTriggerExit(Collider other)
    {
        // preguntar si hay alguien o algo suscrito al evento para que reaccione.
        triggerExitEvent?.Invoke();
    }
    #endregion
}
