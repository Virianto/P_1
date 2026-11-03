using System;
using UnityEngine;

// <summary>
/// AQUI VA EL ENNUNCIADO DEL PROPOSITO DE ESTA CLASE
/// </summary>

public class BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("VSLORES EDITABLES")]

    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;
    [Header("REFERENCIAS")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;
    #endregion

    #region METHODS

  void Update()
    { 
        GameObject newBall = Instantiate(ballPrefab);
        newBall.name = "NuevaEsferaTemporal";
        newBall.tag = "Coin";
        newBall.layer = 6;
    }

  void Start()
    {

        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnOrigin.position;
        for (int i = 0; i < totalSpheresToCreate; ++i)
        {
            GenerateNewPrefab();
        }
    }

    void GenerateNewPrefab()
    {

        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = spawnOrigin.position;
    }

    #endregion
}
