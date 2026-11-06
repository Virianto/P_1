using UnityEngine;
using UnityEngine.UIElements;

public class NewDynamicTrap : MonoBehaviour
{
    KeyCode TrapSwitch = KeyCode.F;
    public GameObject trapDoor;


    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(TrapSwitch))
        {
            trapDoor.SetActive(true);
        }
    }

}