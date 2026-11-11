using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_Enemies : MonoBehaviour
{
    #region ATTRIBUTES

    M_SpawnEnemies myManager;

    [Tooltip("Distancia mínima para cambiar al siguiente punto de ruta")]
    [SerializeField]
    [Range(0.1f, 2)]
    float switchDistance = 0.5f;

    [SerializeField]
    [Range(1, 55)]
    float speed = 2;

    // Variable de puntos de vida
    [SerializeField]
    int lifePoints = 10;

    // Lista de puntos para hacer su ruta/vigilancia cíclica
    List<Vector3> patrolPointsList = new();

    int currentDestinyIndex = 0;

    #endregion
    #region METHODS

    public void InitializeRing(M_SpawnEnemies manager, Vector3 newPosition)
    {
        myManager = manager;
        transform.position = newPosition;

        FillPatrolPointsList();
    }

    void FillPatrolPointsList()
    {
        for (int i = 0; i < 9; ++i)
        {
            // Nos inventamos una serie de puntos para definir nuestra nueva ruta

            Vector3 newPoint = new Vector3(
                Random.Range(-20, 20),
                Random.Range(0, 50),
                Random.Range(-50, 50));

            patrolPointsList.Add(newPoint);
        }
    }

    void Update()
    {
        // Necesito saber si estoy lo bastante cerca o no de mi punto de destino
        float currentDistance = Vector3.Distance
            (transform.position, patrolPointsList[currentDestinyIndex]);

        if (currentDistance < switchDistance)
        {
            // * Cambiar el valor del índice
            currentDestinyIndex = (currentDestinyIndex + 1) % patrolPointsList.Count;
            // Primer caso: 0 = (0 + 1) % 2 -> 1 / 2 me da de resto 1
            // Segundo caso: 1 = (1 + 1) % 2 -> 2 / 2 me da de resto 0
        }
        else
        {
            Vector3 middlePoint = Vector3.Lerp
                (transform.position, patrolPointsList[currentDestinyIndex], Time.deltaTime * speed);

            transform.position = middlePoint;
        }
    }

    public void ModifyEnemyLifePoints(int amount)
    {
        lifePoints += amount;

        if (lifePoints <= 0)
        {
            myManager.FinishBallonLifeCycle(this);
            Debug.Log("me han dado");
        }
    }
    #endregion
}


