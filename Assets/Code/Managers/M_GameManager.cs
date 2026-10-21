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
        // Decirle al canvas que modifique su texto de contrdor facilitándole el valor desde player
        gameplayCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void PlayerRecievedDamage()
    {
        // Informar al canvas que debe actualziar su Slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);

    }
    public void PlayerRecievedHeal()
    {
        // Informar al canvas que debe actualziar su Slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);

    }

    public void EnableTrapButton()
    {
        // Indicr al canvas que debe activar ele botón para poder interactuar
        gameplayCanvas.EnableControlButton();
    }

    public void DisableTrapButton()
    {

        gameplayCanvas.DisableControlButton();

    }

    public void FinishGame()
    {        
        gameplayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
