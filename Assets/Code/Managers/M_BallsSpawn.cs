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

    [SerializeField]
    Transform spawnOrigin;

    #endregion

    #region METHODS
    
    void Start()
    {
        // Generar una instancia del prefab
        GameObject newBall = Instantiate(ballPrefab);

        // Ubicar la esfera en la posición de mi transform de referencia
        newBall.transform.position = spawnOrigin.position;
    }

    #endregion
}
