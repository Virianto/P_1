using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Un Agente que persigue al jugador y la quita monedas
/// </summary>
public class B_ChaserCoinsAgent : MonoBehaviour
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