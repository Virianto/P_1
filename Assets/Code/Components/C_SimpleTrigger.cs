using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
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
        triggerEnterEvent?.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }

    #endregion
}
