using UnityEngine;

public class B_ActivateTrap : MonoBehaviour
{
    public GameObject Trap;
    
    private void OnTriggerEnter(Collider other)
    {
        Trap.SetActive(true);
    }
}
