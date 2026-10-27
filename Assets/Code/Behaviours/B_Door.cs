using UnityEngine;


/// <summary>
/// Detecta un Input del player y rota un ángulo predeterminado
/// </summary>
public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Tecla que debe usar el jugador para accionar esta puerta")]
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;

    // Ángulo:
    [SerializeField]
    [Range(0, 180)]
    float doorAngle = 90;

    // Velocidad de giro:
    [SerializeField]
    [Range(15, 90)]
    float angularSpeed = 30;

    // Saber si está abierta o cerrada
    bool isOpen = false;

    float destinyAngle = 0;

    #endregion





    #region METHODS

    private void Update()
    {
        if(Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }

        float newYValue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);

        Vector3 destinyEulerAngles = new Vector3(0, newYValue, 0);

        transform.Rotate(destinyEulerAngles);
    }

    void SwitchDoorState()
    {
        // Alternar el valor del booleano (asignando el valor contrario con !)
        isOpen = !isOpen;

        if(!isOpen)
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