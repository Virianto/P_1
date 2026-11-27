using Code.Utils;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lista de transforms (puntos vacíos)
/// Lista de colores
/// tiempo / Ease
/// Método ruta, en cada punto cambia color(1->2->3)
/// referencia al cubo e indice actual
/// </summary>
public class M_Animation : Singleton<M_Animation>
{
    #region ATTRIBUTES

    [SerializeField]
    public List<Transform> transformPoints;
    [SerializeField]
    B_AnimatedCube animatedCube;
    [SerializeField]
    GameObject animatedCubeObj;
    List<Color> colorList;
    Material cubeMaterial;
    int currentIndex = 0;

    #endregion

    #region METHODS

    private void Awake()
    {
        cubeMaterial = animatedCubeObj.GetComponent<Renderer>().material;
    }

    private void Start()
    {
        ApplyTweenAnimations();
    }

    //public void GoToPointsRoute(Transform point)
    //{
    //    //foreach (var point in transformPoints)
    //    //{
    //        animatedCube.transform.DOMove(point.position, 3);
    //    //}
    //}

    void switchCurrentIndex()
    {
        currentIndex = (currentIndex + 1) % transformPoints.Count;
        ApplyTweenAnimations();
    }

    void ApplyTweenAnimations()
    {
        animatedCubeObj.transform.DOMove(transformPoints[currentIndex].position, 1);
        cubeMaterial.DOColor(colorList[currentIndex], 1).onComplete += switchCurrentIndex;
    }

    #endregion
}
