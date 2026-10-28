using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_Agents2 : MonoBehaviour
{

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    public GameObject goalPlatform;

    bool agentIsInsideArea = false;

    [SerializeField]
    B_CharacterController player;

    #endregion


    #region METHODS

    void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.SetDestination(goalPlatform.transform.position);
    }



    #endregion
}