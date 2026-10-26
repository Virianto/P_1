using Unity.VisualScripting;
using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    Vector3 destinationPoint = Vector3. zero;
    [SerializeField]
    GameObject Destination;

    #endregion

    #region METHODS

   void Update()
    {
        if (Input.GetMouseButtonDown(0))

       {
            OnDisconnectedFromMouse();
       }
    }
     void OnDisconnectedFromMouse()
    {
        //CREO UNA VARIABLE TEMPORAL PARA ALMACENAR INFORMACION DEL TOQUE
        RaycastHit hit;
        //va a proyectar ese click en la escena 3d  de unity
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit))
        {

            destinationPoint = hit.point;
            Destination.transform.position = destinationPoint;
        }
    }

    #endregion

}
