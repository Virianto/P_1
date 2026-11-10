using UnityEngine;
using UnityEngine.Events;

/// <summary>
<<<<<<< HEAD
/// Aqui va el enunciado del proosito de esta clase
=======
/// * Lanzamiento de un UnityEvent en cada uno de los casos
>>>>>>> develop
/// </summary>
public class C_SimpleTrigger : MonoBehaviour
{
    #region ATTRIBUTES

    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;
<<<<<<< HEAD
    #endregion


    #region METHODS 
    void OnTriggerEnter(Collider other)
    {
=======

    #endregion

    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
>>>>>>> develop
        triggerEnterEvent?.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
=======
        // Preguntar si hay ALGUIEN o ALGO suscrito al evento para que reaccione
>>>>>>> develop
        triggerExitEvent?.Invoke();
    }

    #endregion
}
