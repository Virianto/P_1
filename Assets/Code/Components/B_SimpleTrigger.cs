using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine;
using UnityEngine.Events;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class B_SimpleTrigger : MonoBehaviour
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
