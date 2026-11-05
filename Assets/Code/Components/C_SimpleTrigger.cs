using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
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
        triggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }

    #endregion
}

