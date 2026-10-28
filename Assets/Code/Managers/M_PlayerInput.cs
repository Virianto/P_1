using UnityEngine;
using System.Collections.Generic;

public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    Vector3 destinationPoint = Vector3.zero;

    //[SerializeField]
    //GameObject destinationPS;

    /// <summary>
    /// Lista de todos los agentes q tengo en mi escena
    /// </summary>
    [SerializeField]
    List<B_AgentLife> agentsList = new();

    [SerializeField] 
    B_CharacterController player;

    #endregion


    #region METHODS
    void Update()
    {
        // Detectar q el jugador ha hecho click izquierdo en el ratón
        // if (Input.GetMouseButtonDown(0)) // Si queremos q solo note una pulsación 
        //if (Input.GetMouseButton(0))        // Si queremos que nos detecte cuando arrastramos el ratón con el botón pulsado
        //{
        //    SetDestinationFromMouse();
        //}

        // Le paso como destino la posición del player


        destinationPoint = player.transform.position;
        for (int a = 0; a < agentsList.Count; ++a)  //Creo temporalmente A (0); mientras A sea menor que el número de agentes en mi lista (3) ejecuto lo siguiente; además cada vez A se incrementa en 1
        {
            agentsList[a].SetNewAgentDestination(destinationPoint);
        }
    }
   
    //void SetDestinationFromMouse()
    //{
    //    // Creo una variable temporal para almacenar info del toque
    //    RaycastHit hit;

    //    // Va a proyectar ese click en la escena 3D de unity
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    // Si ha tocado algún plano de escena...
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        // Me guardo el punto donde se ha detectado el toque
    //        destinationPoint = hit.point;
            
    //        // Reubico mi sistema de partículas para poder ver donde hice click
    //        destinationPS.transform.position = destinationPoint;
    //        destinationPS.GetComponent<ParticleSystem>().Emit(10);

    //        // Asignar el destino de TODOS los agentes de mi lista
    //        for (int a = 0; a < agentsList.Count; ++a)  //Creo temporalmente A (0); mientras A sea menor que el número de agentes en mi lista (3) ejecuto lo siguiente; además cada vez A se incrementa en 1
    //        {
    //            agentsList[a].SetNewAgentDestination(destinationPoint);
    //        }
    //    }

    //}
    #endregion
}
