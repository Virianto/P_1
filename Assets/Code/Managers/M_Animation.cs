using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// https://dotween.demigiant.com/documentation.php
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

    int currentPointListIndex;
    int currentColorListIndex;

    [SerializeField]
    Ease animationEase = Ease.OutBounce;

    Sequence cubeAnimationSequence;
    Tween cubeAnimationTween;
    #endregion


    #region METHODS
    // UNA MANERA DE HACERLO
    //void Start()
    //{
    //    // Llamo al método
    //    CubeAnimation();
    //}

    //void CubeAnimation()
    //{
    //    // Animación de que el cubo de mueva al x punto de mi lista de puntos con una animación
    //    cubeAnimationTween = cube.transform.DOMove(pointList[currentPointListIndex].position, time).SetEase(animationEase);
    //    // Mi index de puntos incrementa en uno pero comienza de nuevo si supera el total de puntos de mi lista
    //    currentPointListIndex = (currentPointListIndex + 1) % pointList.Count;


    //    // Animación de que el cubo se mueva de color entre los de mi lista
    //    cube.GetComponent<Renderer>().material.DOColor(colorList[currentColorListIndex], time);
    //    // Mi index de colores incrementa en uno pero comienza de nuevo si supera el total de colores de mi lista
    //    currentColorListIndex = (currentColorListIndex + 1) % colorList.Count;

    //    // Cuando ha terminado la animación vuelve a llamar al método
    //    cubeAnimationTween.onComplete += CubeAnimation;
    //}

    // OTRA MANERA DE HACERLO, CON SECUENCIAS
    void Awake()
    {
        cubeAnimationSequence = DOTween.Sequence();
    }

    void Start()
    {
        // Hay q desactivar el autokill para que no se borre automáticamente la secuencia que vamos a crear
        cubeAnimationSequence.SetAutoKill(false);

        for (int i = 0; i < pointList.Count; i++)
        {
            // Pongo una animación de movimiento en la secuencia
            cubeAnimationSequence.Append(cube.transform.DOMove(pointList[i].position, time));

            // Pongo una animación de color en la secuencia
            cubeAnimationSequence.Append(cube.GetComponent<Renderer>().material.DOColor(colorList[i], time));
        }
        cubeAnimationSequence.Play();
        cubeAnimationSequence.onComplete += cubeAnimationSequence.PlayBackwards;
    }
    #endregion
}
