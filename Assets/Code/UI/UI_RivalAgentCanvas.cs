using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class UI_RivalAgentCanvas : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    Slider rivalLifeSlider;
    #endregion


    #region METHODS
    public void UpdateLifeRivalSlider(int rivalLifePointsLeft)
    {
        rivalLifeSlider.value = rivalLifePointsLeft;
    }

    #endregion
}
