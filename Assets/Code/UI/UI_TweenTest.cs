using DG.Tweening;
using TMPro;
using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class UI_TweenTest : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External references")]

    [SerializeField]
    RectTransform upperPanel;

    [SerializeField]
    TMP_Text upperText;

    [Header("Editable values")]

    [SerializeField]
    string textToShow;

    [SerializeField]
    [Range(0.1f, 5)]
    float animTime = 1;

    bool isShowingPanel = true;

    #endregion





    #region METHODS

    public void ToggleUpperPanelVisibility()
    {
        // Si el panel se está mostrando...
        if (isShowingPanel)
        {
            // Lo escondemos
            upperPanel.DOScale(Vector3.zero, animTime);
        }
        // Si no se está mostrando...
        else
        {
            // Lo mostramos
            upperPanel.DOScale(Vector3.one, animTime);
        }
        // Alternamos el booleano para la siguiente invocación
        isShowingPanel = !isShowingPanel;
    }

    #endregion
}