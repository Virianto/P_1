using UnityEngine;

public class M_GameManager : MonoBehaviour
{    
    #region ATTRIBUTES

    public B_CharacterController player;

    public B_FinalGoal goal;

    public UI_GameOverCanvas gamePlayCanvas;

    #endregion

    #region METHODS

    public void FinishGame()
    {        
        gamePlayCanvas.gameObject.SetActive(true);
    }

    #endregion
}
