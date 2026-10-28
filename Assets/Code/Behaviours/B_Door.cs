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
    [Range(-180, 180)]
    float doorAngle = 90;

    [SerializeField]
    [Range(0, 60)]
    float angularSpeed = 15;

    Vector3 destinyEulerAngles;

    float destinyAngle = 0;
    float newYvalue = 0;

    bool isOpen = false;

    #endregion

    #region METHODS

    void Update()
    {
        if (Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }

        newYvalue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);
        destinyEulerAngles = new Vector3(0, newYvalue, 0);
        transform.rotation = Quaternion.Euler(destinyEulerAngles);    
    }

    void SwitchDoorState()
    {
        // Alternar el valor del booleano (le asigno el valor opuesto al actual)
        isOpen = !isOpen;

        if (!isOpen)
        {
            destinyAngle = 0;
        }
        else
        {
            destinyAngle = 90;
        }
    }

    #endregion
}
