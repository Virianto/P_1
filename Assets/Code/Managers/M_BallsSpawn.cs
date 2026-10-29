using UnityEngine;

/// <summary>
/// Esta clase se ocupa de generar esferas en escena siguiendo algunas condiciones
///     * Ubicar la esfera en una posición concreta (facilitada desde el Editor)
///     * Introducir aleatoriedad en posición de origen y en cantidad de esferas
///     * Añadir físicas en el momento de generar cada esfera
///     * Gestionar el ciclo de vida de las esferas generadas
/// </summary>
public class M_BallsSpawn : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject ballPrefab;

    Vector3 spawnOrigin = new Vector3(10,4,1);

    [SerializeField] [Range(1, 20)] int totalSpheresToCreate = 1;
    [SerializeField][Range(1, 15)] float horizontalXRange = 2;
    [SerializeField][Range(1, 15)] float horizontalZRange = 2;

    #endregion

    #region METHODS

    void Start()
    {
        for (int i = 0; i < totalSpheresToCreate; ++i)
        {
            GeneratePrefabAtCustomOrigin();
        }

    }
    void GeneratePrefabAtRandomOrigin()
    {
        Vector3 newRandomPosition = new Vector3
            (
            Random.Range(-horizontalXRange,horizontalXRange),5,
            Random.Range(-horizontalZRange,horizontalZRange)
            );
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = newRandomPosition;
    }
    void GeneratePrefabAtCustomOrigin()
    {
        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        // Ubicar la esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin;
    }

    #endregion
}
