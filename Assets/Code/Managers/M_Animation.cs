using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class M_Animation : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL VALUES")]
    [SerializeField]
    GameObject cube;

    [SerializeField]
    List<Transform> pointList = new();

    [SerializeField]
    List<Color> colorList = new();

    [Header("EDITABLE VALUES")]
    [SerializeField]
    [Range(0.1f, 15)]
    float time = 5;

    int pointListIndex;
    int colorListIndex;

    [SerializeField]
    Ease animationEase = Ease.OutBounce;

    Tween cubeAnimationTween;
    #endregion


    #region METHODS
    void Start()
    {
        // Llamo al método
        CubeAnimation();
    }

    void CubeAnimation()
    {
        // Animación de que el cubo de mueva al x punto de mi lista de puntos con una animación
        cubeAnimationTween = cube.transform.DOMove(pointList[pointListIndex].position, time).SetEase(animationEase);
        // Mi index de puntos incrementa en uno pero comienza de nuevo si supera el total de puntos de mi lista
        pointListIndex = (pointListIndex + 1) % pointList.Count;


        // Animación de que el cubo se mueva de color entre los de mi lista
        cube.GetComponent<Renderer>().material.DOColor(colorList[colorListIndex], time);
        // Mi index de colores incrementa en uno pero comienza de nuevo si supera el total de colores de mi lista
        colorListIndex = (colorListIndex + 1) % colorList.Count;

        // Cuando ha terminado la animación vuelve a llamar al método
        cubeAnimationTween.onComplete += CubeAnimation;
    }

    #endregion
}
