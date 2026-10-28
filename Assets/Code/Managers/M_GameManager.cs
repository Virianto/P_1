using UnityEngine;
using UnityEngine.SceneManagement;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    //public B_FinalGoal goal;
    public B_Goal goal;

    public UI_GameOverCanvas gameplayCanvas;

    public B_Agents2 npc;

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

        if (player.lifePointsLeft <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
    public void PlayerRecievedHeal()
    {
        // Informar al canvas que debe actualziar su Slider
        gameplayCanvas.UpdateLifeSlider(player.lifePointsLeft);

    }

    public void EnableTrapButton(GameObject controlPlatform, GameObject trapObject)
    {
        // Indicr al canvas que debe activar el botón para poder interactuar
        gameplayCanvas.EnableControlButton(controlPlatform, trapObject);
    }

    public void DisableTrapButton()
    {

        gameplayCanvas.DisableControlButton();

    }

    /*public void GameOver()
    {
        if ()
        {
            SceneManager.LoadScene(0);
        }
    }*/

    public void FinishGame()
    {

        SceneManager.LoadScene(0);

    }  
       


        //gameplayCanvas.gameObject.SetActive(true);
    

    #endregion
}
