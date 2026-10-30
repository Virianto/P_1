using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_interactivewall : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Distancia minima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 1.5f)]
    float switchDistance = 0.5f;

    [SerializeField]
    [Range(1, 10)]
    float speed = 2;

    [SerializeField]
    List<Transform> routePointList = new();

    Transform currentDestinyPoint;

    int currentDestinyIndex = 0;

    #endregion

    #region METHODS

    private void Awake()
    {
        currentDestinyPoint = routePointList[currentDestinyIndex];
    }
    private void Update()
    {
      //if()

        #endregion
    }
    //si player en plataforma, mover pared

}

