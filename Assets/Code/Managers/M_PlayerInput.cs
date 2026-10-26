
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{



    #region ATTRIBUTES

    [SerializeField]
    GameObject destination_PS;

    /// <summary>
    /// Lista de todos los agentes que tengo en mi escena
    /// </summary>
    [SerializeField]
    List<B_Agent> agentsList = new();

    Vector3 destinationPoint = Vector3.zero;

    



    #endregion



    #region METHODS

    private void Update()
    {

        // Detectar que el jugador ha hecho click izquierdo puntual en el ratón
        /*if (Input.GetMouseButtonDown(0))
        {
            SetDestinationFromMouse();


        }*/

        // Detectar en cada FRAME si el botón izquierdo está pulsado
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

        // Si ha tocado algún plano del suelo

        if (Physics.Raycast(ray, out hit))
        {   
            // Me guardo el punto donde ha detectado ese toque
            destinationPoint = hit.point;

            // Reubico el sistema de partículas para VER dónde hice click
            destination_PS.transform.position = destinationPoint;
            destination_PS.GetComponent<ParticleSystem>().Emit(15);

            // Asignar destino a TODOS los agentes de mi lista
            for (int a = 0; a < agentsList.Count; ++a)
            {
                // int a = 0 -> Punto de partida para la primera pregunta del "for"
                // a < agentsList.Count; -> Pregunta del for que me indica si ejecuto el bloque (devuelve TRUE) o he terminado (devuelve FALSE)
                //  ++a -> Modificar una condición al terminar de ejecutar el bloque ANTES de repetir la pregunta

                agentsList[a].SetNewAgentDestination(destinationPoint);
            }
        }

    }





    #endregion
}
