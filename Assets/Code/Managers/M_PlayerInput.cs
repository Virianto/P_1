using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{ 
    #region ATTRIBUTES
    Vector3 destinationPoint = Vector3.zero;
    [SerializeField] GameObject destination_PS;
    #endregion

    #region METHODS
    private void Update()
    {
        // Jugador ha hecho click izquierdo puntual en el raton
        //if (Input.GetMouseButtonDown(0)) //-> una pulsación completa
        //{
        //    SetDestinationFromMouse();
        //    //proyecta ese click en la escena 3D de unity

        //    //si ha tocado algún plano del suelo, me va a indicar en q punto

        //}
        if (Input.GetMouseButton(0)) //-> para una pulsación continua
        {
            SetDestinationFromMouse();
        }
    }

    void SetDestinationFromMouse()
    {
        //variable temporar para almacenar info del toque
        RaycastHit hit;

        //proyeccion del click en la escena
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //si ha tocado el suelo, indica donde
        if (Physics.Raycast(ray, out hit)) //-> si esto existe guardamelo en esta variable q ya existe (en este caso, hit)
        {
            //guarda el punto donde ha detectado ese toque
            destinationPoint = hit.point;
            destination_PS.transform.position = destinationPoint;
        }

    }
    #endregion
}
