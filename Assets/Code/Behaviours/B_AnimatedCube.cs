using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;


/// <summary>
/// * Pruebas con DOTween para mover y animar un objeto
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES


    [SerializeField]
    Transform destinyPointTransform;

    [SerializeField]
    [Range(0.1f, 5)]
    float animationTime = 3;

    [SerializeField]
    Ease animationEase = Ease.Linear;

    [SerializeField]
    LoopType animationLoopType = LoopType.Yoyo;

    Tween cubeAnimationTween;

        
    #endregion

    #region METHODS

    void Start()
    {

        cubeAnimationTween = transform.DOMove(destinyPointTransform.position, animationTime, false).SetEase(animationEase);
        cubeAnimationTween.Play();
        cubeAnimationTween.onComplete += CubeAnimationFinished;

        //transform.DOMove(destinyPointTransform.position, 3, false).SetEase(animationEase);

        // Que el cubo escale al doble de su tamaño en 3 segundos
        //Vector3 newScale = transform.localScale * 2;
        //transform.DOScale(newScale, 3).SetLoops(-1, animationLoopType);
        //GetComponent<Renderer>().material.DOColor(Color.blue, 3);
        
    }

    void CubeAnimationFinished()
    {
        Debug.Log("Moviemiento del cubo finalizado");

        Vector3 newScale = transform.localScale * 2;
        transform.DOScale(newScale, 3).SetLoops(-1, animationLoopType);
        GetComponent<Renderer>().material.DOColor(Color.blue, 3);

    }

    #endregion
}
