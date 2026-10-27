using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_AngeyAgent : MonoBehaviour
{

    #region ATTRIBUTES

    NavMeshAgent myAgent;

    B_CharacterController player;

    #endregion


    #region METHODS
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
    }

    #endregion
}
