using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_LoadPlaneScene : MonoBehaviour
{

    [SerializeField] Button startGameButton;

    void Awake()
    {
        startGameButton.onClick.AddListener(LaunchGame);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }

}
