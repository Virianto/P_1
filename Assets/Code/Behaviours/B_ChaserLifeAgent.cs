using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Un Agente que persigue al jugador y le quita vida
/// </summary>
public class B_ChaserLifeAgent : MonoBehaviour
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