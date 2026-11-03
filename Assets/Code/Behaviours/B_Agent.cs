using UnityEngine;
using UnityEngine.AI;

public enum AgentType
{
    Humanoid,
    Bird,
    Digger
}

/// <summary>
/// * Uno de mis agentes debe detectar colisión con el jugador y quitarle vida
/// * Uno de mis agentes debe detectar colisión con el jugador y quitarle monedas
/// * Uno de mis agentes debe ir corriendo hacia la línea de meta
/// </summary>
public class B_Agent : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hacia ese punto por el camino más óptimo que encuentre

    #region ATTRIBUTES

    [SerializeField]
    AgentType agentType;

    [SerializeField]
    B_CharacterController player;

    NavMeshAgent myAgent;

    #endregion

    #region METHODS

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        SetNewAgentDestination(player.transform.position);
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }

    void OnTriggerEnter(Collider other)
    {
        // Me aseguro que lo que he tocado es el player
        if (other.GetComponent<B_CharacterController>() != null)
        {
            //¿Quién soy y cómo debo comportarme?
            if (agentType == AgentType.Humanoid)
            {
                player.TakeDamage(3);
            }
            else if (agentType == AgentType.Bird)
            {

            }
            else if (agentType == AgentType.Digger)
            {
                player.EarnMoney(-1);
            }
        }        
    }

    #endregion
}
