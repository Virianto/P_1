using UnityEngine;
using DG.Tweening;

/// <summary>
/// * Pruebas con DOTween para mover y animar un objeto
/// </summary>
public class B_AnimatedCube : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Transform destinyPointTransform;

    [SerializeField]
    Color smallColor = Color.blue;

    [SerializeField]
    float duration = 1;

    [SerializeField]
    float shrinkFactor = 0.5f;

    #endregion

    #region METHODS

    void Start()
    {
        // Muevo el cubo al destino (una sola vez, sin loop)
        transform.DOMove(destinyPointTransform.position, duration, false)
                 .SetLink(gameObject);

        // Escala: se encoge y vuelve a su tamaño, en bucle
        transform.DOScale(transform.localScale * shrinkFactor, duration)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine)
                 .SetLink(gameObject);

        // Color: se va azulando al encoger y recupera el original al crecer
        Renderer cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.DOColor(smallColor, duration)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine)
                    .SetLink(gameObject);
    }

    #endregion
}