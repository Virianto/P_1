using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController2 player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gameplayCanvas;

    #endregion

    #region METHODS
    public void NewCoinCollector()
    {
        //decirle al canvas que modifique su texto de contador
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }
    public void PlayerReceiveDamage()
    {
        //informar al canvas de que debe actualizar su slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }
    public void FinishGame()
    {        
        gameplayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
