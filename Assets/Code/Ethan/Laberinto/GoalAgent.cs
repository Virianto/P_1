using UnityEngine;
using UnityEngine.AI;

public class GoalAgent : MonoBehaviour
{

    [SerializeField] GameObject Goal;
    NavMeshAgent myAgent;

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        myAgent.SetDestination(Goal.transform.position);
    }
}
