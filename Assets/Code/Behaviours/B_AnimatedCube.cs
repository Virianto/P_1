using UnityEngine;
using DG.Tweening;

/// <summary>
/// Aquí la descripcion de qué hace la clase
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    Transform destinyPointTransform;
    [SerializeField]
    M_Animation animationManager;

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

    private void Start()
    {
        //cubeAnimationTween = transform.DOMove(destinyPointTransform.position, animationTime).SetEase(animationEase);
        //cubeAnimationTween.Play();
        //cubeAnimationTween.onComplete += CubeAnimationFinished;

        //M_Animation.Instance.GoToPointsRoute(animationManager.transformPoints[0]);
    }

    void CubeAnimationFinished()
    {
        Debug.Log("Movimiento del cubo finalizado");
        //Que el cubo escale al doble de su tamaño
        transform.DOScale(transform.localScale * 2, animationTime).SetLoops(-1, animationLoopType);
        GetComponent<MeshRenderer>().material.DOColor(Color.aliceBlue, animationTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name.Contains("point"))
        //{
        //    M_Animation.Instance.GoToPointsRoute(animationManager.transformPoints[1]);
        //}
    }

    #endregion
}
