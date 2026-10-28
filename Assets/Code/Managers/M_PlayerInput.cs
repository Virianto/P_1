using System.Collections.Generic;
using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    GameObject destinationParticleSystem;

    /// <summary>
    /// Lista de todos los agentes que tengo en mi escena
    /// </summary>
    [SerializeField]
    List<B_Agent> agentList = new();


    Vector3 destinationPoint = Vector3.zero;

    #endregion

    #region METHODS

    // Input.GetMouseButton(1) <- sirve para detectar todo el rato el click presionado 

    private void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            setDestinationFromMouse();
        }
    }

    void setDestinationFromMouse()
    {
        //Me creo una variable temporal para almacenar informacion del toque
        RaycastHit hit;

        //va a projectar ese click en la escena 3D de unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Si ha ocado algun plano de escena...
        if (Physics.Raycast(ray, out hit))
        {
            //Me guardo el punto donde ha detectatdo ese toque
            destinationPoint = hit.point;

            // reubico el sistema de particulas para ver donde hace click
            destinationParticleSystem.transform.position = destinationPoint;

            //asignar el destino  todos los agentes que tengo en mi lista
            for (int i = 0; i < agentList.Count; i++)
            {
                //agentList[i].setNewAgentDestination(destinationPoint);
            }
        }

    #endregion
    }
}
