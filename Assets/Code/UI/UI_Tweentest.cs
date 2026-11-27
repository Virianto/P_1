using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class UI_Tweentest : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL REFERENCE")]

    [SerializeField]
    RectTransform upperPanel;

    [SerializeField]
    TMP_Text upperText;

    [Header("EDITABLE VALUES")]
    [SerializeField]
    string textToShow;

    [SerializeField][Range(0.1f,5)]
    float animTime = 1;

    bool isShowingPanel = true;
    bool isShowingText = false;
    #endregion


    #region METHODS
    public void ToggleUpperPanelVisibility()
    {
        if (isShowingPanel)
        {
            // Quiero esconderlo
            upperPanel.DOScale(Vector3.zero,animTime);
        }
        else
        {
            // Quiero mostrarlo
            upperPanel.DOScale(Vector3.one, animTime);
        }
        // Alterno el booleano para la siquiente invocación
        isShowingPanel = !isShowingPanel;
    }
    public void ToggleLowerTextContent() 
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
