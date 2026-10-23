using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gameOverCanvas;


    #endregion

    #region METHODS

    public void NewCoinCollected()
    {
        //decirle al canvas que modifique su texto de contador facilitandole el valor desde player
        gameOverCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerReceivedDamage() //informar al canvas
    {
        gameOverCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void PlayerHealed() //informar al canvas
    {
        gameOverCanvas.UpdateLifeSlider(player.lifePointsLeft);
    }

    public void EnableTrapButton(GameObject trapObject)
    {
        gameOverCanvas.EnableControlButton(trapObject);
    }

    public void DisableTrapButton()
    {
        gameOverCanvas.DisableControlButton();
    }

    public void FinishGame()
    {        
        gameOverCanvas.gameObject.SetActive(true);
    }

    #endregion
}
