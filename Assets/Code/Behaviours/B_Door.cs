using UnityEngine;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T; //la T es una tecla ejemplo le puedo poner cualquier tecla

    [SerializeField]
    [Range(0, 180)]
    float doorAngle = 90; //angulo de apertura

    [SerializeField]
    [Range(15, 90)]
    float doorSpeed = 30; //velocidad angular

    float destinyAngle = 0;

    bool isOpen = false;


    #endregion

    #region METHODS

    private void Update()
    {
        if(Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }
        float newValue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * doorSpeed);
        Vector3 destinyEulerAngles = new Vector3(0, newValue, 0);
        transform.Rotate(destinyEulerAngles);
    }

    void SwitchDoorState()
    {
        //alternar el valor del booleano(le asigno el valor opuesto al actual)
        isOpen = !isOpen;
        if(isOpen )
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

