using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manager que controla los movimientos de los 'AngeyAgents'
/// </summary>
public class M_AgentsInput : MonoBehaviour
{
    #region ATTRIBUTRES

    [SerializeField]
    B_CharacterController player;
    [SerializeField]
    List<B_AngeyAgent> angeyAgentsList = new();
    [SerializeField]
    List<B_AngeyAgent> runningAgentsList = new();
    
    
    [SerializeField]
    GameObject finishLine;


    Vector3 targetPoint = Vector3.zero;
    

    #endregion

    #region METHODS

    void Update()
    {
            MoveAgentToPlayer();
        Vector3 newFinishLine = finishLine.transform.position;
        MoveAgentToFinishLine(newFinishLine);
    }

    void MoveAgentToPlayer()
    {
        for (int a = 0; a < angeyAgentsList.Count; ++a)
        {
            targetPoint = player.transform.position;
            angeyAgentsList[a].MoveToPlayerDestination(targetPoint);
        }
    }

    void MoveAgentToFinishLine(Vector3 newFinishLine)
    {
        for(int a = 0;a < runningAgentsList.Count; ++a)
        {
            runningAgentsList[a].MoveToFinishLine(newFinishLine);
        }
    }
    #endregion

}
