using UnityEngine;
using System.Collections.Generic;

public class M_PlayerInput : MonoBehaviour
{
    /*detectar que el jugador hace click izquierdo en el raton
     * proyectar ese click en la escena 3d de unity
     * si ha tocado algun punto del suelo, indicar en que punto
     * */

    #region ATTRIBUTES

    Vector3 destinationPoint = Vector3.zero;

    [SerializeField]
    ParticleSystem ps;

    [SerializeField]
    List<B_Agent> agentsList = new();

    #endregion

    #region METHODS

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationFromMouse();
        }
    }

    void SetDestinationFromMouse()
    {
        //variable temporal que almacena informacion del toque
        RaycastHit hit;
        //proyectar el click en la escena de unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //si ha tocado algun punto de la escena...
        if(Physics.Raycast(ray, out hit))
        {
            //me guardo el punto en el que ha dectectado ese toque
            destinationPoint = hit.point;
            ps.transform.position = destinationPoint;

            //asignar el destino a todos los agentes que tengo en mi lista
            for (int i = 0; i < agentsList.Count; i++) //l letra da igual y el ++ se puede poner tambien por delante ej el profe tiene ++a
            {
                agentsList[i].SetNewAgentDestination(destinationPoint);
            }
        }
        destinationPoint = Vector3.zero;
    }

    #endregion 
}
