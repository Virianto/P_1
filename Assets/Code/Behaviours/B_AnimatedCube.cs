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

    #endregion

    #region METHODS

    void Start()
    {
        transform.DOMove(destinyPointTransform.position, animationTime, false)
            .SetEase(animationEase);

        // Que el cubo escale al doble de su tamaño en 3 segundos
        Vector3 newScale = transform.localScale * 2;
        transform.DOScale(newScale, animationTime).SetLoops(-1, animationLoopType);
    }


    #endregion
}
