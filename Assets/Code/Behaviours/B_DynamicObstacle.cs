using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Tiene 2 puntos en escena y se va a mover entre ellos  
/// </summary>
public class B_DynamicObstacle : MonoBehaviour
{
    #region ATTRIBUTES


    [Tooltip("Distancia minima para cambiar al siguiente punto de ruta")] [SerializeField] [Range(0.1f, 1.5f)] float switchDistance = 0.5f;
    [SerializeField] [Range(1f,10f)] float speed = 2;
    [SerializeField] List<Transform> routePointsList = new();
    Transform currentDesitnyPoint;
   
    #endregion

    #region METHODS
    void Update()
    {
        
    }
    #endregion
}
