using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manager que controla los movimientos de los 'AngeyAgents'
/// </summary>
public class M_AgentsInput : MonoBehaviour
{
    #region ATTRIBUTRES
    [SerializeField]
    List<B_AngeyAgent> angeyAgentsList = new();

    B_CharacterController player;

    Vector3 targetPoint = Vector3.zero;

    #endregion

    #region METHODS

    void Update()
    {
            MoveAgentToPlayer();
    }

    void MoveAgentToPlayer()
    {
        for (int a = 0; a < angeyAgentsList.Count; ++a)
        {
            targetPoint = player.transform.position;
            angeyAgentsList[a].MoveToPlayerDestination(targetPoint);
        }
    }
    #endregion

}
