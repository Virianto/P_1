using UnityEngine;
using DG.Tweening;

/// <summary>
/// Purebas con DOTween para mover y animar un objeto
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{

    #region ATTRIBUTES


    [Header("EXTERNAL REFERENCES")]
    
    [SerializeField]
    Transform destinyPointTransform;

    [Space(10)]
    
    [Header("EDITABLE VALUES")]
    
    [SerializeField]
    Vector3 newScale = new Vector3 (2,2,2);

    [SerializeField]
    [Range(0.1f, 10f)]
    float animationTime = 3;


    [SerializeField]
    Ease animationEase= Ease.Linear;

    [SerializeField]
    LoopType animationLoopType = LoopType.Yoyo;
    #endregion


    #region METHODS


    void Start()
    {
        transform.DOMove(destinyPointTransform.position,animationTime,false).SetEase(animationEase);
        transform.DOScale(newScale, animationTime).SetLoops(-1, animationLoopType);
        B_AnimatedCube cubeMaterial = GetComponent<B_AnimatedCube>();
        cubeMaterial.GetComponent<Renderer>().material.DOColor(Color.blue, animationTime).SetLoops(-1,animationLoopType);
    }
    void Update()
    {

    }


    #endregion
}
