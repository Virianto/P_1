using UnityEngine;

/// <summary>
/// Detecta un input del jugador y rota un ángulo predeterminado
/// </summary>
public class X_B_Door : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Tecla que debe pulsar el jugador para accionar la puerta")]
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;

    //* Ángulo
    [SerializeField]
    [Range(0, 180)]
    float doorAngle = 90;
    //* Velocidad angular
    [SerializeField]
    [Range(15, 90)]
    float angularSpeed = 30;
    
    float destinyAngle = 0;
    //* Booleano
    bool isOpen = false;
    #endregion

    #region METHODS

    private void Update()
    {
        if (Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }
    }

    void SwitchDoorState()
    {
        //Alternar el valor del bool (le asigno el valor opuesto del actual)
        isOpen = !isOpen;

        if (!isOpen)
        {
            destinyAngle = doorAngle;
        }

        float newYvalue = Mathf.Lerp
            (transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);
        
        Vector3 destinyEulerAngles = new Vector3(0, newYvalue, 0);
        transform.Rotate(destinyEulerAngles);
    }
    #endregion
}
