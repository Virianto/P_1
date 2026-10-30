using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    
    #region ATTRIBUTES

    /*recibir la orden de dirigirse hacia un punto del mapa
     * moverse hacia ese punto por el camino mas optimo que encuentre
     */

    NavMeshAgent myAgent;

    [SerializeField]
    B_CharacterController player;

    public enum AgentType //ejemplos de distintos agents que funcionaran en los ifs del triggerenter
    {
        Humanoid,
        Bird,
        Digger,
    }

    #endregion

    #region METHODS
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SetNewAgentDestination(player.transform.position);
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        //cambiar el destino de mi agente
        myAgent.SetDestination(newDestination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<B_CharacterController>() != null)
        {
         ////if(agentType == AgentType.Humanoid)
         ////{
                 //este if es para por si tengo varios agentes a hacen ocsas distintas al player
         ////}
        }
       
    }

    #endregion
}
