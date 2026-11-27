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

    Sequence cubeAnimationSequence;

    Material cubeMaterial;

    int currentIndex = 0;

    #endregion

    #region METHODS

    void Awake()
    {
        cubeAnimationSequence = DOTween.Sequence();

        // Me guardo una referencia persistente al material del cubo para escribir menos
        cubeMaterial = animatedCube.GetComponent<Renderer>().material;

        
    }

    void Start()
    {
        for (int i = 0; i < pathPointsList.Count; ++i) 
        {
            // Pongo una animación de movimiento en la secuencia
            cubeAnimationSequence.Append(
                animatedCube.transform.DOMove(pathPointsList[i].position, animTime));

            // Pongo una animación de color en la secuencia
            cubeAnimationSequence.Append(cubeMaterial.DOColor(colorsList[i], animTime));
        }       

        cubeAnimationSequence.Play();

        //cubeAnimationSequence.onComplete += cubeAnimationSequence.PlayBackwards;
    }

    //void Start()
    //{
    //    ApplyTweenAnimations();
    //}
    //void SwitchCurrentIndex()
    //{
    //    currentIndex = (currentIndex + 1) % pathPointsList.Count;
    //    ApplyTweenAnimations();
    //}
    //void ApplyTweenAnimations()
    //{
    //    // Hago dos cosas al mismo tiempo: Mover el cubo y cambiar su color
    //    animatedCube.transform.DOMove(pathPointsList[currentIndex].position, animTime);
    //    cubeMaterial.DOColor(colorsList[currentIndex], animTime)
    //        .onComplete += SwitchCurrentIndex;
    //}

    #endregion
}
