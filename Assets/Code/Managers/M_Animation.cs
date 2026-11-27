using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_Animation : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    List<Transform> transformPointsList = new();

    [SerializeField]
    List<Color> colorsList = new();
    int currentIndex = 0;

    [SerializeField]
    [Range(0.1f, 5)]
    float animationTime = 2;

    [SerializeField]
    Ease animationEase = Ease.Linear;

    [SerializeField]
    GameObject myCube;

    Sequence cubeAnimationSequence;
    Material cubeMaterial;

    #endregion



    #region METHODS
    private void Awake()
    {

        cubeAnimationSequence = DOTween.Sequence();

        // Me guardo una referencia persistente al material del cubo para escribir menos
        cubeMaterial = myCube.GetComponent<Renderer>().material;
    }

    void Start()
    {
        //ApplyTweenAnimations();
        for (int i = 0; i < transformPointsList.Count; ++i)
        {
            // Pongo una animación de movimiento en la secuencia
            cubeAnimationSequence.Append(
                myCube.transform.DOMove(transformPointsList[i].position, animationTime));

            // Pongo una animación de color en la secuencia
            cubeAnimationSequence.Append(cubeMaterial.DOColor(colorsList[i], animationTime));
        }

        cubeAnimationSequence.Play();
        cubeAnimationSequence.onComplete += cubeAnimationSequence.PlayBackwards;

    }
    
    //void SwitchCurrentIndex()
    //{
    //    currentIndex = (currentIndex + 1) % transformPointsList.Count;
    //    ApplyTweenAnimations();
    //}
    //void ApplyTweenAnimations()
    //{
    //    // Hago dos cosas al mismo tiempo: Mover el cubo y cambiar su color
    //    myCube.transform.DOMove(transformPointsList[currentIndex].position, animationTime);
    //    cubeMaterial.DOColor(colorsList[currentIndex], animationTime)
    //        .onComplete += SwitchCurrentIndex;
    //}


    #endregion
}