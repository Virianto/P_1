using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class UI_EnemyCanvas : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] Slider enemyLifeSlider;

    #endregion





    #region METHODS

    public void UpdateEnemyLifeSlider(int enemyLifePointsLeft)
    {
        // Actualizo el valor del slider para que coincida con la vida del enemigo
        enemyLifeSlider.value = enemyLifePointsLeft;
    }

    #endregion
}