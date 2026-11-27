using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class M_SequenceAnimation : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject cube;

    [SerializeField]
    List<Transform> transformList = new();

    [SerializeField]
    List<Ease> easeList = new();

    [SerializeField]
    List<Color> colorList = new();

    [SerializeField]
    List<float> timeList = new();

    Tween animationTween;

    Sequence animationSequence;

    #endregion




    #region METHODS

    private void Awake()
    {
        animationSequence = DOTween.Sequence();
    }

    private void Start()
    {
        for (int i = 0; i < transformList.Count; ++i)
        {
            animationSequence.Append(cube.transform.DOMove(transformList[i].position, timeList[i]).SetEase(easeList[i]));

            animationSequence.Append(cube.GetComponent<Renderer>().material.DOColor(colorList[i], timeList[i]));
        }

        animationSequence.Play();

        animationSequence.onComplete += animationSequence.PlayBackwards;
    }

    #endregion
}