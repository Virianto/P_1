using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Tiene dos puntos en escena y se va a mover de forma ciclica
/// </summary>
public class B_DynamicObstacle : MonoBehaviour
{
    #region ATTRIBUTES

    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField][Range(0.1f, 2)] float switchDistance = 0.5f;
    [SerializeField] [Range(1, 10)] float speed=2;
    [SerializeField] List<Transform> routePointList=new();
    Transform currentDestinyPoint;
    int currentDestinyIndex=0;

    #endregion

    #region METHODS
    void Awake(){
        currentDestinyPoint=routePointList[currentDestinyIndex];
    }

    void Update(){
        //necesito saber si estoy lo bastante cerca o no de mi destino
        float currentDistance=Vector3.Distance(transform.position, currentDestinyPoint.position);
        
        if(currentDistance <= switchDistance)
        {
            //si ya estoy cerca, cambio de destino
            //cambiar valor indice
            currentDestinyIndex=(currentDestinyIndex + 1) % routePointList.Count;

            //1º caso: =(0+1) % 2 = 1 /2 -> resto 1
            //2º caso: =(1+1) % 2 = 0 /2 -> resto 0
            //asignar nuevo destino
            currentDestinyPoint=routePointList[currentDestinyIndex];

        }
        else
        {
            //si estoy lejos, me acerco
            Vector3 middlePoint = Vector3.Lerp
                (transform.position, currentDestinyPoint.position, speed * Time.deltaTime);
            transform.position = middlePoint;
        }
        
    }
    #endregion
}
