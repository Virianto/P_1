using UnityEngine;
using DG.Tweening;

/// <summary>
/// * Pruebas con DOTween para mover y animar un objeto
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Transform destinyPointTransform;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(0.1f, 5)]
    float animationTime = 2;

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
        //cubeAnimationTween.onComplete += CubeAnimationFinished;        
        cubeAnimationTween.OnComplete(CubeAnimationFinished); 
    }

    void CubeAnimationFinished()
    {
        Debug.Log("Movimiento del cubo finalizado");

        // Que el cubo escale al doble de su tamaño en 3 segundos
        Vector3 newScale = transform.localScale * 3;
        transform.DOScale(newScale, animationTime/2).SetLoops(-1, animationLoopType);
    }

    #endregion
}
