using UnityEngine;
using DG.Tweening;

/// <summary>
/// Pruebas con DOTween para animar objetos
/// </summary>
public class B_AnimatedObject
    : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("External References")]

    [SerializeField]
    Transform destinyPointTransform;

    [Header("Editable values")]

    [SerializeField]
    [Range(0.1f, 5)]
    float animationTime = 2.5f;

    [SerializeField]
    Ease animationEase = Ease.Linear;

    [SerializeField]
    LoopType animationLoopType = LoopType.Yoyo;

    [SerializeField]
    Color color;

    [SerializeField]
    Vector3 scale = new Vector3();

    Tween animationTween;

    #endregion





    #region METHODS

    private void Start()
    {
        // Mover el objeto
        animationTween = transform.DOMove(destinyPointTransform.position, animationTime).SetEase(animationEase);

        animationTween.Play();

        animationTween.onComplete += AnimationFinished;
    }

    void AnimationFinished()
    {
        // Escalar el objeto
        transform.DOScale(scale, animationTime).SetLoops(-1, animationLoopType);

        // Cambiar el color al objeto
        GetComponent<Renderer>().material.DOColor(color, animationTime);
    }


    #endregion
}