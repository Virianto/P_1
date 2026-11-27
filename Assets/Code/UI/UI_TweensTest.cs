using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class UI_TweensTest : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    RectTransform upperPanel;

    [SerializeField]
    TMP_Text upperText;

    [Header("EDITABLE VALUES")]

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
        // Aquí podríamos jugar con las anclas para que se "despliegue" de otra forma
        if (isShowingPanel)
        {
            upperPanel.DOScale(Vector3.zero, animTime);
        }
        else
        {
            upperPanel.DOScale(Vector3.one, animTime);
        }
        // Alterno el booleano para la siguiente invocación del método
        isShowingPanel = !isShowingPanel;
    }

    /// <summary>
    /// Esto solamente valía para la versión PRO de DOtween (por si la quieres pagar)
    /// </summary>
    public void ToggleUpperTextContent()
    {
        if (isShowingText)
        {
            // Vacío el texto del panel                       
        }
        else
        {
            // Relleno el texto del panel
        }
            // Alterno el booleano para la siguiente invocación del método
            isShowingText = !isShowingText;
    }

    #endregion
}
