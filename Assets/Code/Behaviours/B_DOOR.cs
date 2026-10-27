using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class B_DOOR : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    KeyCode doorSwitchKey = KeyCode.T;
    float doorAngle = 90;
    [SerializeField]
    [Range(15, 90)]
    float angularSpeed = 30;
    float destinyAngle = 0;

    bool isOpen=false;
    #endregion

    #region METHODS
    void Update()
    {
        if (Input.GetKeyDown(doorSwitchKey))
        {
            SwitchDoorState();
        }
        float NewYvalue = Mathf.Lerp(transform.rotation.eulerAngles.y, destinyAngle, Time.deltaTime * angularSpeed);
        Vector3 desrinyeulerAngles = new Vector3(0, NewYvalue, 0);
    }
    void SwitchDoorState()
    {
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
