using UnityEngine;
using System.Collections.Generic;

public class M_PlayerInput : MonoBehaviour
{
    //Va a proyectar ese click en la escena 3D de Unity
    //Si ha tocado algún plano del suelo, me va a indicar en qué punto

    #region ATTRIBUTES

    Vector3 destinationPoint = Vector3.zero;
    [SerializeField]
    GameObject destination_PS;

    /// <summary>
    /// Lista de todos los agentes que tengo en mi escena
    /// </summary>
    [SerializeField]
    List<B_Agent> agentsList = new();
    #endregion

    #region METHODS

    void Update()
    {   //Va a detectar que el jugador ha hecho click izquierdo puntual en el ratón
        //if (Input.GetMouseButtonDown(0))

        //Detectar en cada FRAME si el botón izquierdo está pulsado
        if(Input.GetMouseButton(0))
        {
            
            SetDestinationFromMouse();
            
        }
    }
    void SetDestinationFromMouse()
    {
        //Creo variable temporarl para almacenar información del toque
        RaycastHit hit;

        //Va a proyectar ese click en la escena 3D de Unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Si ha tocado algún plano de escena, 
        if(Physics.Raycast(ray, out hit))
        {
            //Me guardo el punto donde ha detectad ese toque
            destinationPoint = hit.point;
            //Reubico el sistema de partículas para VER dónde hice click
            destination_PS.transform.position = destinationPoint;
            destination_PS.GetComponent<ParticleSystem>().Play();

            //Asignar el destino a TODOS los agentes que tengo en mi lista
            for (int a = 0; a < agentsList.Count; a++) 
            {
                agentsList[a].SetNewAgentDestination(destinationPoint);
            }
        }
    }
    #endregion
}
