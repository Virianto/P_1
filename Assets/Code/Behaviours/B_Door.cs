using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Detecta un input del jugador y rota un angulo determinado
/// </summary>

public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Tecla que debe pulsar el jugador para accionar esta puerta")]
    [SerializeField]
    KeyCode doorSwicthKey = KeyCode.E;

    [SerializeField]
    [Range(0,180)]
    float doorAngle = 90;

    [SerializeField]
    [Range(15, 90)]
    float angularSpeed = 30;

    float destinyAngle = 0;

    bool isOpen = false;

    #endregion
    #region METHODS

    private void Update()
    {
        if (Input.GetKeyDown(doorSwicthKey))
        {
            SwicthDoorState();
        }
        float newYValue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);

        Vector3 destinyEulrAngles = new Vector3(0, newYValue, 0);

        transform.Rotate(destinyEulrAngles);
    }

    void SwicthDoorState()
    {
        isOpen = !isOpen;

        if (isOpen)
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

