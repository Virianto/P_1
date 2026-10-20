using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gameplayCanvas;

    #endregion

    #region METHODS

    public void NewCoinCollected()
    {
        //Decirle al canvas que modifique su texto de contador facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void FinishGame()
    {        
        gameplayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
