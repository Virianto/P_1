using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Animation : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject cube;

    [SerializeField]
    List<Transform> transformList = new();

    [SerializeField]
    List<Ease> easeList = new();

    [SerializeField]
    List<Color> colorList = new();

    [SerializeField]
    List<float> timeList = new();

    int currentTransformIndex = 0;
    int currentColorIndex = 0;
    int currentEaseIndex = 0;
    int currentTimeIndex = 0;

    Tween animationTween;

    #endregion





    #region METHODS

    private void Start()
    {
        RuteChanges();
    }

    void RuteChanges()
    {
        // Animación para que el objeto se mueva al siguiente punto de la lista de posiciones
        animationTween = cube.transform.DOMove(transformList[currentTransformIndex].position, timeList[currentTimeIndex]).SetEase(easeList[currentEaseIndex]);
        // Incremento del índice de puntos
        currentTransformIndex = (currentTransformIndex + 1) % transformList.Count;
        currentEaseIndex = (currentEaseIndex + 1) % easeList.Count;
        currentTimeIndex = (currentTimeIndex + 1) % timeList.Count;

        // Animación para que el objeto cambie al siguiente color de la lista de colores
        cube.GetComponent<Renderer>().material.DOColor(colorList[currentColorIndex], timeList[currentTimeIndex]);
        // Incremento del índice de colores
        currentColorIndex = (currentColorIndex + 1) % colorList.Count;

        // Reiniciamos el método cuando termina la animación de movimiento
        animationTween.onComplete += RuteChanges;
    }

    #endregion
}