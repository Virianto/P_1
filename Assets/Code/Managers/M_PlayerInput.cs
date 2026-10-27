using UnityEngine;
using System.Collections.Generic;

public class M_PlayerInput : MonoBehaviour
{

    #region ATTRIBUTES

    Vector3 destinationPoint = Vector3.zero;

    [SerializeField] GameObject destination_PS;

    /// <summary>
    /// Lista de todos los agentes que tenemos en mi escena
    /// </summary>
    [SerializeField] List<B_Agent> agentList = new();

    #endregion





    #region METHODS

    private void Update()
    {
        // Detectar que el jugador ha hecho click izquierdo en el ratón (con cada click)
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationFromMouse();
        }

        /*
         * // Detectar que el jugador ha hecho click izquierdo en el ratón (con un click y moviendo el mouse)
         * if(Input.GetMouseButton(0))
        {
            SetDestinationFromMouse();
        }
        */
    }

    void SetDestinationFromMouse()
    {
        // Crear una variable temporal para almacenar información del click
        RaycastHit hit;

        // Proyectar el click del jugador en la escena de Unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Si ha tocado algún punto del plano del suelo
        if(Physics.Raycast(ray, out hit))
        {
            // Guardamos el punto donde ha tocado
            destinationPoint = hit.point;

            // Reubicamos el sistema de partículas para ver dónde hemos hecho click
            destination_PS.transform.position = destinationPoint;

            // Asignamos el destino a todos los agentes que tenemos en la lista
            for (int a = 0; a < agentList.Count; ++a)
            {
                agentList[a].SetNewAgentDestination(destinationPoint);
            }
        }
    }

    #endregion
}
