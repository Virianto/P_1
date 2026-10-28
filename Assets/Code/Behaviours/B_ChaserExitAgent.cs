using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_ChaserExitAgent : MonoBehaviour
{
    #region ATTRIBUTES

    NavMeshAgent myAgent;

    #endregion





    #region METHODS

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        // Cambiar el destino del Agente
        myAgent.SetDestination(newDestination);
    }

    #endregion
}