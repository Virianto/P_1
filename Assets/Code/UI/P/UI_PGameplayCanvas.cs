using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_PGameplayCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    public M_PManager gameManager;

    [SerializeField]
    TMP_Text coinsCounterText;

    [SerializeField]
    TMP_Text chronoText;

    public float gameplayTime = 15;

    #endregion

    #region METHODS

    void Awake()
    {
        //Inicializar el texto que se muestra por pantalla cada vez que inicio el nivel
        coinsCounterText.text = "00";
        chronoText.text = "00:00:00";
    }

    public void UpdateCounter(int coinsCollected)
    {
        coinsCounterText.text = coinsCollected.ToString();
    }

    public void GainTime()
    {
        gameplayTime += 1f;
    }

    void Update()
    {
        //En cada frame le sumo a mi crono l tiempo transcurrido el último frame
        gameplayTime -= Time.deltaTime;
        chronoText.text = TimeFormatter.FormatTime(gameplayTime);

    }

    #endregion
}
