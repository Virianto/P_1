
using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_destino : MonoBehaviour
{
    #region ATTRIBUTES

    Vector3 destinationPoint = Vector3.zero;

    [SerializeField]
    GameObject destino;

    [SerializeField]
    List<B_Agent> agentsList = new();

    #endregion

    #region METHODS

    private void Update()
    {
        destinationPoint = destino.transform.position;
        
        for (int i = 0; i < agentsList.Count; i++)
        {
            agentsList[i].SetNewAgentDestination(destinationPoint);
        }

        destinationPoint = Vector3.zero;
    }

    #endregion
}

