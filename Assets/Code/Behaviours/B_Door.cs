using Unity.VisualScripting;
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
    [Range(0, 180)]
    float doorAngle = 90;

    [SerializeField]
    [Range(15, 90)]
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
            Debug.Log("Se ha detectado la tecla y destinyAngle vale: " + destinyAngle);
        }

        float newYvalue = Mathf.Lerp
            (transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);

        Vector3 destinyEulerAngles = new Vector3(0, 90, 0);

        transform.rotation.SetFromToRotation(transform.rotation.eulerAngles, destinyEulerAngles);
    }

    void SwitchDoorState()
    {
        // Alternar el valor del booleano (le asigno el valor opuesto al actual)
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
