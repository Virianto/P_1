using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    GameObject destinationParticleSystem;

    Vector3 destinationPoint = Vector3.zero;

    #endregion

    #region METHODS

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
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
        if(Physics.Raycast(ray, out hit))
        {
            //Me guardo el punto donde ha detectatdo ese toque
            destinationPoint = hit.point;
            destinationParticleSystem.transform.position = destinationPoint;
        }
    }

    #endregion 
}
