using UnityEngine;

public class CharacterController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        B_Coin coinDetected = other.GetComponent<B_Coin>();

        if (coinDetected != null )
        {

        }
    }
}
