using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_StartCanvas : MonoBehaviour
{

    [SerializeField] Button startGameButton;


    void Awake()
    {
        startGameButton.onClick.AddListener(LaunchGame);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

}

