using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Aquí la descripcion de qué hace la clase
/// </summary>
public class UI_TweenTestCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    RectTransform upperPanel;

    [SerializeField]
    TMP_Text upperText;

    [Header("EDITABLE VALUES")]

    TMP_Text textToShow;

    [SerializeField]
    [Range(0.1f, 5)]
    float animTime = 1;

    bool isShowingPanel = true;
    bool isShowingText = false;

    #endregion

    #region METHODS

    public void ToggleUpperPanelVisibility()
    {
        if (isShowingPanel)
        {
            //esconderlo
            upperPanel.DOScale(Vector3.zero, animTime);
        } 
        else
        {
            //mostrarlo
            upperPanel.DOScale(Vector3.one, animTime);
        }

        isShowingPanel = !isShowingPanel;
    }

    public void ToggleUpperTextContent()
    {
        if (isShowingText) 
        { 
            ////Vacío el texto del panel
            //upperText.text.Do
        } 
        else
        {
            //Relleno el texto
        }

        isShowingPanel = !isShowingPanel;
    }

    #endregion
}
