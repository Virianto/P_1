
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// Uno de mis agentes debe detectar colisión con el jugador y quitarle vida
/// Uno de mis agentes debe detectar colisión con el jugador y quitarle monedas
/// Uno de mis agentes debe ir corriendo hacia la línea de meta
/// </summary>
public class B_Agents2 : MonoBehaviour
{

    #region ATTRIBUTES


    NavMeshAgent myAgent;

    public GameObject goalPlatform;

    bool agentIsInsideArea = false;

    [SerializeField]
    B_CharacterController player;

    public enum AgentType
    {
        Humanoid,
        Brid,
        Digger
    }

    
    #endregion


    #region METHODS

    /*void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        SetNewDestination(goalPlatform.transform.position);
    }

    public void SetNewDestination()
    {
        myAgent.SetDestination(goalPlatform.transform.position);

        if (other.GetComponent<B_CharacterController>())
        {


        }
            
    }*/

    #endregion
}