using UnityEngine;
using UnityEngine.AI;

public class B_Agent : MonoBehaviour
{
    // Recibir la orden de dirigirse hacia un punto del mapa
    // Va a moverse hacia ese punto por el camino más óptimo que encuentre

    #region ATTRIBUTES
    [SerializeField]
    GameObject player;
    NavMeshAgent myAgent;

    #endregion

    #region METHODS
    private void Update()
    {
        myAgent.SetDestination(player.transform.position);
    }
    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetNewAgentDestination(Vector3 newDestination)
    {
        myAgent.SetDestination(newDestination);
    }

    #endregion
}
