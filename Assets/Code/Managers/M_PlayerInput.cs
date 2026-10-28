using UnityEngine;
using System.Collections.Generic;


public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    //referencia al jugador 

    [SerializeField]
    GameObject destination_PS;

    //referencia al jugador 
    [SerializeField]
    Transform playerLocation;

    /// <summary>
    /// Lista de todos los agentes que tengo en mi escena
    /// </summary>
    [SerializeField]    
    List<B_Agent> agentsList = new();

    Vector3 destinationPoint = Vector3.zero;

    #endregion

    #region METHODS

    void Update()
    {
        SetDestinationFromPlayer();
    }

    void SetDestinationFromPlayer()
    {
        // Asignar la posición actual del jugador a TODOS los agentes de mi lista
        for (int a = 0; a < agentsList.Count; ++a)
        {
            agentsList[a].SetNewAgentDestination(playerLocation.position);
        }
    }

    #endregion
}
