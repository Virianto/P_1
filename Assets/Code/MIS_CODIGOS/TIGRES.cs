using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// DETECCION SENCILLA DE CUANDO ENTRA UN OBJETO 
/// DETECCION SENCILLA DE CUANDO sale UN OBJETO 
/// </summary>
public class TIGRES : MonoBehaviour
{
    #region ATTRIBUTES
    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;
    #endregion

    #region METHODS
    void OnTriggerEnter(Collider other)
    {
        //preguntar si hay alguien o algo suscrito al evento par que reaccione
        triggerEnterEvent?.Invoke();
        
    }

    void OnTriggerExit(Collider other)
    {
        //preguntar si hay alguien o algo suscrito al evento par que reaccione
        triggerExitEvent?.Invoke();
    }
    #endregion
}
