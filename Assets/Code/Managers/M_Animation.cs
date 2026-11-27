
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class M_Animation : MonoBehaviour
{

    #region ATTRIBUTES


    [Header("EXTERNAL REFERENCES")]
    [SerializeField]
    B_AnimatedCube cube;
    
    [SerializeField]
    List<Transform> pointsList = new();

    [SerializeField]
    List<Color> colorList = new();


    [Header("EDITABLE VALUES")]
    [SerializeField]
    [Range(0.1f, 10)]
    float animationTime = 2;

    [SerializeField]
    Ease easeType = Ease.Linear;


    Tween cubeMovementTween;
    Tween cubeColorTween;

    int currentPointIndex = 0;
    int currentColorIndex = 0;

    #endregion


    #region METHODS

    void Start()
    {
        RouteOfCube();
    }

    //Se mueve a la dirección indicada y luego llama a cambiar de color
    void RouteOfCube()
    {
      
        cubeMovementTween = cube.transform.DOMove(pointsList[currentPointIndex].position,animationTime).SetEase(easeType);
        cubeMovementTween.Play();
        currentPointIndex = (currentPointIndex + 1) % pointsList.Count;
        cubeMovementTween.onComplete += ColorOfCube;
        //cubeMovementTween.onComplete += CubeMovementFinished; //Llamada a este método si queremos que cambie de color mientras se mueve
            

    }

    //Cuando llega al punto, cambia de color y después retoma la ruta
    void ColorOfCube()
    {
        cubeColorTween = cube.GetComponent<Renderer>().material.DOColor(colorList[currentColorIndex], animationTime);
        cubeColorTween.Play();
        currentColorIndex = (currentColorIndex + 1) % colorList.Count;
        cubeColorTween.onComplete += RouteOfCube;
       
    }

    //Si queremos que siga el camino y mientras tanto cambie de color, hay que seguir este método
    //void CubeMovementFinished()
    //{
    //    cube.GetComponent<Renderer>().material.DOColor(colorList[currentColorIndex], animationTime);
    //    currentColorIndex = (currentColorIndex + 1) % colorList.Count;
    //    cubeMovementTween = cube.transform.DOMove(pointsList[currentPointIndex].position, animationTime).SetEase(easeType);
    //    cubeMovementTween.Play();
    //    currentPointIndex = (currentPointIndex + 1) % pointsList.Count;
    //    cubeMovementTween.onComplete += CubeMovementFinished;
    //}
    #endregion
}
