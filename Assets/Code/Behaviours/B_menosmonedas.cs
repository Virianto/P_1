using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_menosmonedas : MonoBehaviour
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

    [SerializeField]
    [Range(0, 10)]
    int collisionDamage = 1;

    bool playerIsInsideArea = false;

    [SerializeField]
    B_CharacterController player;

    #endregion

    #region METHODS

    private void Awake()
    {
        currentDestinyPoint = routePointList[currentDestinyIndex];
    }
    private void Update()
    {
        //necesito saber si estoy cerca de mi destino o no. si estoy lejos me sigo acercando. si estoy cerca cambio de punto de destino
        float currentDistance = Vector3.Distance(transform.position, currentDestinyPoint.position);

        if (currentDistance <= switchDistance)
        {
            //cambio punto de destino
            currentDestinyIndex = (currentDestinyIndex + 1) % routePointList.Count;

            currentDestinyPoint = routePointList[currentDestinyIndex];
        }
        else
        {
           
            Vector3 middlePoint = Vector3.Lerp(transform.position, currentDestinyPoint.position, Time.deltaTime * speed); //Lerp interpola entre dos puntos
            transform.position = middlePoint;
        }

    }

    private void OnTriggerEnter(Collider other) //quitar monedas al player
    {
        playerIsInsideArea = true;

    }
    #endregion
}

