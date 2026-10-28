using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Tiene dos puntos en escena y se mueve entre ellos de forma cíclica
/// </summary>
public class NewDynamicObstacle : MonoBehaviour
{
    public Transform goal;

    void OnEnable()
    {
        transform.position = goal.position;
    }


}
