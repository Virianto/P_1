using System.Collections.Generic;
using UnityEngine;

public class M_PlayerImput : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    List<B_Agent> agentList = new();


    [SerializeField]

    GameObject destination_Ps;

    Vector3 destinationPoint = Vector3.zero;

    #endregion
    #region METHODS 
    void Update()
    {
            if (Input.GetMouseButton(0))
            //if (Input.GetMouseButtonDown(0))
        {
          SetDestinationFromMouse();
        }
    }
    void SetDestinationFromMouse()
    {
        //Me cro una variable temporal para almacenar infomacion del toque
        RaycastHit hit;

        //Va z proyectar es click en la escena 3d de unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Si ah tocado algun plano...
        if (Physics.Raycast(ray, out hit))

        {
            //Me guardo el punto donde ha detectado ese toque
            destinationPoint = hit.point;
            destination_Ps.transform.position = destinationPoint;
        }
            //asignar el destino a todos los agentes que tengo en mi lista
            for (int a = 0; a < agentList.Count;a += 2)
            {
                agentList[a].SetNewAgentDestination(destinationPoint);
            }
        }
    #endregion
    }
