
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Propósito de esta clase
/// </summary>
public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES

    //[ToolTip("Tecla para abrir/cerrar la puerta")]
    [SerializeField] KeyCode doorSwitchKey=KeyCode.T;

    //angulo
    [SerializeField][Range(0, 180)] float doorAngle=90;
    //velocidad angular
    [SerializeField][Range(15, 90)] float angularSpeed = 30;
    //bool para saber si la puerta está abierta o cerrada
    bool isOpen=false;

    float destinyAngle=0;

    #endregion

    #region METHODS

    void Update()
    {
        if(Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }
        float newYValue=Mathf.Lerp
            (transform.rotation.eulerAngles.y, destinyAngle, angularSpeed * Time.deltaTime);
        Vector3 destinyEulerAngles = new Vector3(0, newYValue, 0);
        transform.rotation.SetFromToRotation(transform.rotation.eulerAngles, destinyEulerAngles);
    }

    void SwitchDoorState()
    {
        //alternar valor booleano
        isOpen = !isOpen;

        if(!isOpen) {
            destinyAngle=doorAngle;
        }else{
            destinyAngle=0;
        }
    }
    #endregion
}
