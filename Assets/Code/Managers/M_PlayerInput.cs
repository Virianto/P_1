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
        ////Detectar que mi jugador Ha hecho clic izquierdo
        //if (Input.GetMouseButtonDown(0)) //0 clic izq, 1 clic derecho, 2 rueda
        //{
        //    //Va a proyectar el clic en la escena de Unity
        //    SetDestinationFromMouse();
        //}
        if (Input.GetMouseButton(0))
        {
            SetDestinationFromMouse();
            //destination_PS.GetComponent<ParticleSystem>().Emit(5);
        }
    }

    void SetDestinationFromMouse()
    {
        //Me creo una variable temporal para almacenar la información del toque
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Si ha tocado algún plano de escena, me va a indicar en qué punto
        if (Physics.Raycast(ray, out hit))
        {
            //Me guardo el punto donde ha detectado ese toque
            destinationPoint = hit.point;

            //Reubico el sistema de particulas para ver el clic de manera visual
            destination_PS.transform.position = destinationPoint;

            //Asignar el destino a TODOS los agentes que tengo en mi lista
            for (int i = 0; i < agentsList.Count; i++) 
            {
                agentsList[i].SetNewDestinationByPlayer(destinationPoint);
                Debug.Log(agentsList[i].name);
            }
        }
    }
    #endregion
}
