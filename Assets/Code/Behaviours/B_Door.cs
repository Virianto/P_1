using UnityEngine;
/// <summary>
/// detecta un input del jugador
/// </summary>
public class B_Door : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] KeyCode doorSwitchKey = KeyCode.T;
    [SerializeField] [Range(0, 180)] float doorAngle = 90;
    [SerializeField] [Range(15, 90)] float angularSpeed = 30;
    float destinyAngle = 0;
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
        Vector3 destinyEulerangles = new Vector3(0,newYvalue,0);
        transform.Rotate(destinyEulerangles);
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
