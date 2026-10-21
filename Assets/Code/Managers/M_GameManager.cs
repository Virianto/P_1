using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    //public B_FinalGoal goal;

    public UI_GameOverCanvas gameOverCanvas;

    #endregion

    #region METHODS

    public void NewCoinsCollected()
    {
        gameOverCanvas.UpdateCounter(player.totalCoinsCollected);
    }

    public void FinishGame()
    {        
        gameOverCanvas.gameObject.SetActive(true);
    }

    #endregion
}
