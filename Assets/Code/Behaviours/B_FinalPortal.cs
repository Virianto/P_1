using UnityEngine;

public class B_FinalPortal : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] KeyCode finishGameKey = KeyCode.F;

    B_CharacterController player;

    bool playerCanFinishGame = false;

    #endregion




    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        playerCanFinishGame = true;
        player = other.GetComponent<B_CharacterController>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(finishGameKey))
        {
            if (playerCanFinishGame)
            {
                ShowLevelCompletionMessage();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerCanFinishGame = false;
    }

    void ShowLevelCompletionMessage()
    {
        int totalCoinsCollected = player.totalYellowCoinsCollected + player.totalRedCoinsCollected + player.totalBlueCoinsCollected;

        if (totalCoinsCollected >= 6)
        {
            Debug.Log("¡Felicidades!");
        }
        else
        {
            Debug.Log("Todavía te faltan monedas");
        }
    }

    #endregion
}
