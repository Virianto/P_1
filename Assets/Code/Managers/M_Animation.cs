using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class M_Animation : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    GameObject animatedCube;

    [SerializeField]
    List<Transform> pathPointsList = new();

    [SerializeField]
    List<Color> colorsList = new();

    [Header("EDITABLE VALUES")]

    [SerializeField]
    Ease ease = Ease.Linear;

    [SerializeField]
    [Range(0.1f, 5)]
    float animTime = 1;

    Material cubeMaterial;

    int currentIndex = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        // Me guardo una referencia persistente al material del cubo para escribir menos
        cubeMaterial = animatedCube.GetComponent<Renderer>().material;
    }

    void Start()
    {
        ApplyTweenAnimations();
    }
    void SwitchCurrentIndex()
    {
        currentIndex = (currentIndex + 1) % pathPointsList.Count;
        ApplyTweenAnimations();
    }
    void ApplyTweenAnimations()
    {
        // Hago dos cosas al mismo tiempo: Mover el cubo y cambiar su color
        animatedCube.transform.DOMove(pathPointsList[currentIndex].position, animTime);
        cubeMaterial.DOColor(colorsList[currentIndex], animTime)
            .onComplete += SwitchCurrentIndex;
    }

    #endregion
}
