using UnityEngine;
using System.Collections.Generic;

public class M_PlayerInput : MonoBehaviour
{

    Vector3 destinationPoint = Vector3.zero;
    [SerializeField] ParticleSystem destination_PS;
    /// <summary>
    /// Lista de todos los agentes que tengo en mi escena
    /// </summary>
    [SerializeField] List<B_Agent> agentsList = new();

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // el 0 es click izquierdo, el 1 es click derecho y el 2 es click rueda
        {
            SetDestinationFromMouse();
        }
    }

    void SetDestinationFromMouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            destinationPoint = hit.point;
            destination_PS.transform.position = destinationPoint;
            destination_PS.Play();

            for (int a = 0; a < agentsList.Count; a += 2)
            {
                agentsList[a].SetNewAgentDestination(destinationPoint);  
            }
        }

    }



}
