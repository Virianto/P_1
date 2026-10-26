using UnityEngine;

public class M_PlayerInput : MonoBehaviour
{
    #region ATTRIBUTES
    Vector3 destinationPoint = Vector3.zero;

    [SerializeField]
    GameObject destination_PS;
    #endregion


    #region METHODS
    void Update()
    {
        if (input.GetMouseButtonDown(0))
        {
            SetDestinationFromMouse();




        }
    }
    void SetDestinationFromMouse()
    {
        RaycastHt hit;
        Ray ray = Camera.main.ScreenpointToRay(M_PlayerInput.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            destinationPoint = hit.point;
            destination_PS.transform.position = desinatinPoint;
        }

    }
    #endregion
}
