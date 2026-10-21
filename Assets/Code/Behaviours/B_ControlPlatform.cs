using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
{
    public M_GameManager gameManager;
    public GameObject TrapGameObject;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.EnableTrapButton();
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
