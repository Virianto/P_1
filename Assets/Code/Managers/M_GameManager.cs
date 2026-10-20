using UnityEngine;

public class M_GameManager : MonoBehaviour
{
    #region ATTRIBUTES

    public B_CharacterController player;

    public UI_GameOverCanvas gameOverCanvas;

    public B_Meta meta;

    #endregion

    #region METHODS

    public void FinishGame()
    {
        Debug.Log("Enorabuena has recogido todas las monedas");
        gameOverCanvas.gameObject.SetActive(true);
    }

    #endregion
}
