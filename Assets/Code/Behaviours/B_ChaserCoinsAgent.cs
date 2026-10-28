using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Agente que persigue al jugador y la quita monedas
/// </summary>
public class B_ChaserCoinsAgent : MonoBehaviour
{
    #region ATTRIBUTES

    NavMeshAgent myAgent;
    bool playerIsInsideArea = false;

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

    void OnTriggerEnter(Collider other)
    {
        // Detectar cuándo ha entrado el jugador en su área de efecto
        playerIsInsideArea = true;

    }

    void OnTriggerExit(Collider other)
    {
        // Detectar cuándo ha salido el jugador de su área de efecto
        playerIsInsideArea = false;
    }

    #endregion
}