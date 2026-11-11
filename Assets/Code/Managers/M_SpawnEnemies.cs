using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class M_SpawnEnemies : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    List<Transform> allSpawnsPointsList = new();

    List<B_Enemies> allInstantiatedRingsLists = new();

    [SerializeField]
    GameObject ringPrefab;

    int currentSequenceIndex = 0;

    int currentEnemiesInScene = 0;

    [SerializeField]
    [Range(1, 10)]
    int maxBalloonsInScene = 3;

    #endregion
    #region METHODS

    private Vector3 GenerateRandomPosition()
    {
        currentSequenceIndex = Random.Range(0, allSpawnsPointsList.Count);
        Vector3 spawnPosition = allSpawnsPointsList[currentSequenceIndex].position;
        return spawnPosition;
    }

    void GeneratePrefab(Vector3 newPosition)
    {
        B_Enemies newRing = Instantiate(ringPrefab).GetComponent<B_Enemies>();
        allInstantiatedRingsLists.Add(newRing);
        newRing.InitializeRing(this, newPosition);
        currentEnemiesInScene += 1;
    }

    private void Start()
    {
        StartCoroutine(InvocarEnemigo());
    }
    IEnumerator InvocarEnemigo()
    {
        if (currentEnemiesInScene < maxBalloonsInScene)
        {
            Vector3 posicion = GenerateRandomPosition();
            GeneratePrefab(posicion);
        }
        yield return new WaitForSeconds(Random.Range(3, 10));
        StartCoroutine(InvocarEnemigo());
    }

    public void FinishBallonLifeCycle(B_Enemies balloon)
    {
        // Ojo aquí, siempre destruyo el GAMEOBJECT
        Destroy(balloon.gameObject);

        // Reduzco el contador de enemigos actuales para poder crear más
        currentEnemiesInScene -= 1;
    }

    #endregion
}

