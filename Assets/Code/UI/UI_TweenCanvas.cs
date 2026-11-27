using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class UI_TweenCanvas : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    RectTransform upperPanel;

    [SerializeField]
    TMP_Text upperText;

    [SerializeField]
    string textToShow;

    [SerializeField]
    [Range(0.1f, 5)]
    float animTime = 1;

    bool isShowingPanel = true;
    bool isShowingText = false;

    #endregion



    #region METHODS

    public void ToggleUpperPanelVisibility()
    {

        if(isShowingPanel)
        {
            // Quiero esconderlo
            upperPanel.DOScale(Vector3.zero, animTime);
        }
        else
        {
            // Quiero mostrarlo
            upperPanel.DOScale(Vector3.one, animTime);
        }
        // Alterno el booleano para la siguiente invocación
        isShowingPanel = !isShowingPanel;

    }
        

    //public void ToggleUpperTextContent()
    //{

    //    if (isShowingText)
    //    {
    //        // Vacío el texto del panel                       
    //    }
    //    else
    //    {
    //        // Relleno el texto del panel
    //    }
    //    // Alterno el booleano para la siguiente invocación 
    //    isShowingText = !isShowingText;

    //}

    #endregion
}