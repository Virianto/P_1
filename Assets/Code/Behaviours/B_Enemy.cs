using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// * Este objeto debe tener X puntos de vida
/// * Este objeto debe inventarse una lista de 5 puntos para hacer una ruta cíclica
/// * Este objeto debe desaparecer cuando su vida llega a 0 solamente
/// </summary>
public class B_Enemy : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    [Range(1, 10)]
    public float lifePoints = 10;

    // Ver B_Dynamic_Obstacle
    [SerializeField]
    [Range(0.1f, 20)]
    float switchDistance = 2;

    int currentDestinyIndex = 0;

    [SerializeField]
    [Range(1, 100)]
    float speed = 3;

    [Space]

    [SerializeField]
    GameObject enemyPrefab;

    M_Enemies enemiesManager;

    // Lista de puntos para hacer su ruta

    List<Vector3> patrolPointsList = new();
    // Se podría hacer con array:
    // Vector3[] patrolPointsArray;
    #endregion

    #region METHODS

    public void InitializeEnemy(M_Enemies manager, Vector3 spawnPosition)
    {
        enemiesManager = manager;
        transform.position = spawnPosition;

        FillPatrolPointsList();

    }

    void FillPatrolPointsList()
    {
        // Nos tenemos q inventar una serie de puntos para definir nuestra nueva ruta
        // Vamos a repetir un proceso de manera secuencial
        for(int i = 0; i < 9; ++i)
        {
            // - Crear un nuevo vector3 de vectores aleatorios
            Vector3 newPoint = new Vector3(
                Random.Range(-20, 20),
                Random.Range(-15, 15),
                Random.Range(-50, 50));
            // - Añadir un vector3 a la lista
            
            patrolPointsList.Add(newPoint);
        }
    }

    // Método de recorrer ruta
    private void Update()
    {
        // Cojo el siguiente punto de mi lista de patruya y me aproximo
        // Comparo si estoy lo bastante cerca y
        // Si lo estoy -> paso al siguiente
        // si NO lo estoy -> me sigo acercando
        float currentDistance = Vector3.Distance
            (transform.position, patrolPointsList[currentDestinyIndex]);

        if (currentDistance < switchDistance) // Si ya estoy cerca
        {
            // Cambio de destino
            currentDestinyIndex = (currentDestinyIndex + 1) % patrolPointsList.Count;

        }
        else // Si estoy lejos
        {
            // Me sigo acercando
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
            enemiesManager.FinishEnemyLifeCycle(this);
        }

    }

    // Método de finalizar ciclo de vida
    public void FinishLifeCycle()
    {
        Destroy(this);
        
    }

    #endregion
}
