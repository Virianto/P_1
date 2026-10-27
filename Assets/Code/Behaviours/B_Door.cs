using UnityEngine;

/// <summary>
/// Detecta un input del jugador y rota un ángulo predeterminado 
/// </summary>
public class B_Door : MonoBehaviour
{

    #region ATTRIBUTES

    [Tooltip("Tecla que debe pulsar el jugador para accionar esta puerta")]
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;

    [SerializeField]
    [Range(0,180)]
    float doorAngle = -90;

    [SerializeField]
    [Range(15,90)]
    float angularSpeed = 30;

    float destinyAngle = 0;

    bool isOpen = false;

    #endregion


    #region METHODS

    void Update()
    {
     if (Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }

        float newYvalue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, angularSpeed*Time.deltaTime);
        Vector3 destinyEulerAngles = new Vector3(0, newYvalue, 0);
        //transform.rotation.SetLookRotation(destinyEulerAngles); 
    }

    void SwitchDoorState()
    {
        //Alternar el valor del booleano
        isOpen = !isOpen;

        if (!isOpen)
        {
            destinyAngle = doorAngle;
        }
        else
        {
            destinyAngle = 0;
        }
    }

    #endregion
}
