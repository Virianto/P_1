using UnityEngine;
using UnityEngine.Events;

public class AROS_TRIGGERS : MonoBehaviour
{
    // Lista de acciones que se configuran en el Inspector
    [SerializeField]
    UnityEvent onPlayerEnter;

    void OnTriggerEnter(Collider other)
    {
        // Busca el script en este objeto o en cualquiera de sus padres
        F_B_PlayerPlane plane = other.GetComponentInParent<F_B_PlayerPlane>();

        // Si no lo encuentra, devuelve null (vacío)
        if (plane != null)
        {
            onPlayerEnter?.Invoke();
        }
    }
}