using DG.Tweening;
using UnityEngine;

public class EH_M_Animator : MonoBehaviour
{
    [SerializeField] Transform destinyPoint1Transform;
    [SerializeField] Transform destinyPoint2Transform;
    Ease animationEase = Ease.Linear;


    Tween cubeAnimationTween1;
    Tween cubeAnimationTween2;

    void Start()
    {
        cubeAnimationTween1 = transform.DOMove(destinyPoint1Transform.position, 1, false).SetEase(animationEase);
        cubeAnimationTween1.Play();
        cubeAnimationTween1.onComplete += CubeAnimationFinished1;

    }

    void CubeAnimationFinished1()
    {
        gameObject.GetComponent<Renderer>().material.DOColor(Color.green, 1);

        cubeAnimationTween2 = transform.DOMove(destinyPoint2Transform.position, 1, false).SetEase(animationEase);
        cubeAnimationTween2.Play();
        cubeAnimationTween2.onComplete += CubeAnimationFinished2;
    }

    void CubeAnimationFinished2()
    {
        gameObject.GetComponent<Renderer>().material.DOColor(Color.deepSkyBlue, 1);
    }
}
