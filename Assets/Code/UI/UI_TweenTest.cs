using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class UI_TweenTest : MonoBehaviour
{

    #region ATTRIBUTES
    [Header("EXTERNAL REFERENCES")]
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    RectTransform upperPanel;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    string textToShow;

    [SerializeField]
    [Range(0.1f,10)]
    float animTime = 3;


    bool isShowingPanel = true;
    bool isShowingText = false;

    #endregion


    #region METHODS

    public void ToggleUpperPanelVisibility()
    {
        if (isShowingPanel) 
        {
            upperPanel.DOScale(Vector3.zero, animTime);
        }
        else
        {
            upperPanel.DOScale(Vector3.one, animTime);
        }
        isShowingPanel = !isShowingPanel;
    }
    public void ToggleUpperTextContent()
    {
        if (isShowingText) 
        {
            
        }
        else
        {

        }
            isShowingText = !isShowingText;
    }

    #endregion
}
