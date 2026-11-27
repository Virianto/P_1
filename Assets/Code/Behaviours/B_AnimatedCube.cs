using UnityEngine;
using DG.Tweening;


/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Transform destinyPointTransform;
    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(0.1f, 5f)]
    float animationTime = 2;

    [SerializeField]
    Ease animationEase = Ease.Linear;

    [SerializeField]
    LoopType animationLoopType = LoopType.Yoyo;

    [SerializeField]
   



    #endregion

    #region METHODS 
    private void Start()
    {
        transform.DOMove(destinyPointTransform.position, 3, false).SetEase(animationEase);
        Vector3 newScale = transform.localScale * 2;
        transform.DOScale(newScale, 3).SetLoops(-1,LoopType.Yoyo );

    }
    #endregion
}
