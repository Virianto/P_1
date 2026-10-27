using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 
/// </summary>
public class NewAgent : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent myAgent;
    Vector3 destinationPoint = Vector3.zero;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        myAgent.SetDestination(player.transform.position);
    }

}
