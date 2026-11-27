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

    #endregion

    #region METHODS

    void Start()
    {
        transform.DOMove(destinyPointTransform.position, 3, false);
        // Que el cubo escale al doble de su tamaño en 3 segundos
    }


    #endregion
}
