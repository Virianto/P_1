using UnityEngine;
using DG.Tweening;

/// <summary>
/// Pruebas con DOTWeen para mover y animar un objeto
/// https://dotween.demigiant.com/documentation.php
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES
    [Header("EXTERNAL VALUES")]
    [SerializeField]
    Transform destinyPointTransform;

    [Header("EDITABLE VALUES")]
    [SerializeField]
    Vector3 newScale = new Vector3(3, 3, 3);

    [Space]

    [SerializeField][Range(0.1f, 10)]
    float timeTransform = 3;
    [SerializeField][Range(0.1f, 10)]
    float timeScale = 3;
    [SerializeField][Range(0.1f, 10)]
    float timeColor = 3;

    [Space]

    [SerializeField]
    Ease animationEase = Ease.OutBounce;
    [SerializeField]
    LoopType animationLoopType = LoopType.Yoyo;
    [SerializeField]
    Color color;

    Tween cubeAnimationTween;
    #endregion


    #region METHODS
    void Start()
    {
        // Guardamos la animación para poderla usar
        // Se mueve al punto en X (3 seg, en este caso) y NO va a saltos, además tiene una animación (al final rebota hacia dentro, en este caso)
        cubeAnimationTween = transform.DOMove(destinyPointTransform.position, timeTransform, false).SetEase(animationEase);
        cubeAnimationTween.Play();

        // Cuando la animación de cubeAnimationTween termine hará lo que haya en el método CubeAnimationFinish
        cubeAnimationTween.onComplete += CubeAnimationFinish;

        // Cambiar el color al indicado en el tiempo indicado
        GetComponent<Renderer>().material.DOColor(color, timeColor).SetLoops(-1, animationLoopType);
    }

    void CubeAnimationFinish()
    {
        Debug.Log("Movimiento del cubo finalizado");

        // Otra manera de hacerlo: Vector3 newScale = transform.localScale / timeTransform;
        // Crece a la nueva escala en X (3 seg, en este caso), además la animación, en este caso, se repite en loop un núm infinito de veces como un yoyo/pingpong
        transform.DOScale(newScale, timeScale).SetLoops(-1, animationLoopType);
    }
    #endregion
}
