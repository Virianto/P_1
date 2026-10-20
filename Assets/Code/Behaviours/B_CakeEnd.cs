using UnityEngine;

public class B_CakeEnd : MonoBehaviour
{
    public M_GameManager gameManager;



    private void OnTriggerEnter(Collider other) //End gama
    {
        gameManager.finishGame();
    }


}
