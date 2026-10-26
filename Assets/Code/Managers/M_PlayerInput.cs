using UnityEngine;
using System.Collections.Generic;
public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject destination_PS;
    // <summary>
    /// LISTA DE TODOS LOS AGENTES QUE TENGO EN MI ESCENA
    /// </summary>

    [SerializeField]
    List<B_Agent> agentsList = new();
    Vector3 destinationPoint = Vector3.zero;

    #endregion

    #region METHODS

    void Update()
    {
        // Detectar que el jugador ha hecho click izquierdo en el ratón
        if (Input.GetMouseButton(0))
        {
            SetDestinationFromMouse();            
        }
    }

    void SetDestinationFromMouse()
    {
        // Me creo una variable temporal para almacenar información del toque
        RaycastHit hit;

        // Va a proyectar ese click en la escena 3D de Unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Si ha tocado algún plano de escena...
        if(Physics.Raycast(ray, out hit))
        {
            // Me guardo el punto donde ha detectado ese toque
            destinationPoint = hit.point;

            // Reubico el sistema de partículas para VER dónde hice click
            destination_PS.transform.position = destinationPoint;
            for (int a = 0; a < agentsList.Count; ++a)
            {
                agentsList[a].SetNewAgentDestination(destinationPoint);
            }
        }
    }

    #endregion
}
