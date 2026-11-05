using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Detección sencilla de cuando un objeto entra en el trigger
/// ... cuando sale del trigger
/// Lanzamiento UnityEvent en cada uno de los casos
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
        //Preguntar si hay alguien o algo suscrito al evento para que reaccione
        triggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }

    #endregion
}
