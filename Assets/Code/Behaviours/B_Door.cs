using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

/// <summary>
/// Detecta un imput del jugador y rota un ángulo predeterminado
/// </summary>
public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES
    [Tooltip("Tecla q debe pulsar el jugador para accionar esta puerta")]
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;

    // Ángulo
    [SerializeField]
    [Range(-90,90)]
    float doorAngle = 90;

    // Velocidad angular
    [SerializeField]
    [Range(15,90)]
    float angularSpeed = 30;

    // Booleano para saber si está abierta o cerrada
    bool isOpen = false;

    private float destinyAngle = 0;

    #endregion


    #region METHODS
    void Update()
    {
        if(Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }

        float newYValue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);

        Vector3 destinyEulerAngle = new Vector3(0, newYValue,0);

        transform.rotation.SetEulerAngles(destinyEulerAngle);
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
