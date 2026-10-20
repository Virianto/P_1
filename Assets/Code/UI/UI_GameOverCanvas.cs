using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_GameManager gameManager;

    [SerializeField]
    Button replayGameButton;

    #endregion
    #region METHODS

    private void Awake()
    {
        replayGameButton.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {

        SceneManager.LoadScene(0);
    }

    #endregion
}
