using UnityEngine;
using UnityEngine.Events;

public class C_SimpleTrigger : MonoBehaviour
{

    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent?.Invoke();
    }
    void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke();
    }

}
