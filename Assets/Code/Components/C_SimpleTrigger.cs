using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// * Detección sencilla de cuándo entra un objeto en el trigger
/// * Detección sencilla de cuándo sale un objeto del trigger
/// * Lanzamiento de un  UnityEvent en cada uno de los casos
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
