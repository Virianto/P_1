using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_AgentRival : MonoBehaviour
{
    #region ATTRIBUTES
    NavMeshAgent myAgent;

    [SerializeField]
    B_CharacterController myPlayer;

    [Tooltip("Velocidad a la que se mueve")]
    [SerializeField]
    [Range(1, 20)]
    float speed = 2;

    [Tooltip("Distancia a la que se da la vuelta")]
    [SerializeField]
    [Range(0.1f, 10)]
    float switchDistance = 2;

    [SerializeField]
    List<Transform> routePointsList = new();

    int currentDestiny = 0;

    #endregion


    #region METHODS
    public void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }
    public void Start()
    {
        myAgent.speed = speed;
        myAgent.stoppingDistance = switchDistance;
        Goal();
    }

    public void Goal()
    {
        myAgent.SetDestination(routePointsList[currentDestiny].position);
    }
 
    #endregion
}
