using DG.Tweening;
using UnityEngine;

public class EH_AnimatedCube : MonoBehaviour
{
    [SerializeField] Transform destinyPointTransform;
    [SerializeField] [Range(0.1f,5)] float animationTime;
    [SerializeField] Ease animationEase = Ease.Linear;
    [SerializeField] LoopType animationLoopType = LoopType.Yoyo;
    Tween cubeAnimationTween;

    void Start()
    {
        cubeAnimationTween = transform.DOMove(destinyPointTransform.position,2,false).SetEase(animationEase);
        cubeAnimationTween.Play();
        cubeAnimationTween.onComplete += CubeAnimationFinished;
        
    }

    void CubeAnimationFinished()
    {
        transform.DOScale(5, animationTime).SetLoops(-1, animationLoopType);
        gameObject.GetComponent<Renderer>().material.DOColor(Color.HSVToRGB(246, 100,100), 1);
    }

}
