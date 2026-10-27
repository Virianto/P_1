using UnityEngine;

/// <summary>
/// Deetecta input del jugador y rotaun ángulo predeterminado
/// </summary>
public class B_Door : MonoBehaviour
{

    #region ATTRIBUTES

    [Tooltip("Tecla que debe pulsar el jugador para accionar esta puerta")]
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;

    // * Ángulo
    [SerializeField]
    [Range(0, 360)]
    float doorAngle = 90;

    // * Velocidad angular
    [SerializeField]
    [Range(15, 90)]
    float angularSpeed = 30;

    float destinyAngle = 0;



    // * Booleano para saber si está abierta o cerrada
    bool isOpen = false;



    #endregion



    #region METHODS

    private void Update()
    {
        if (Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }

        float newYvalue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);

        Vector3 destinyeEulerAngles = new Vector3(0, newYvalue, 0);

        transform.rotation.;


    }

    void SwitchDoorState()
    {
        // Alternar el valor del booleano (leasigno el valor opuesto al actual)
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