using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_TrapDoorChildCollider : MonoBehaviour
{
#region ATTRIBUTES

#endregion

#region METHODS
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            // Aquí puedes agregar la lógica que deseas ejecutar cuando el jugador entra en el collider del hijo de la trampilla
            Debug.Log("NPC entered the trap door child collider.");
        }
    }
    #endregion
}
