using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger para modificar velocidad (X cada vez que paso)
/// ...para sumar puntos
/// ...para quitar vida
/// ...para sumar tiempo
/// </summary>
public class C_RingsTriggers : MonoBehaviour
{
    #region ATTRIBUTES

    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }

    #endregion
}
