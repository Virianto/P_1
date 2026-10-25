using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_PGameOverCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Button startGameButton;

    #endregion

    #region METHODS

    void Awake()
    {
        startGameButton.onClick.AddListener(LaunchGame);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(4);
    }

    #endregion
}
