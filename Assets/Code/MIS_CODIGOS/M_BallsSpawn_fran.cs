using UnityEngine;

/// <summary>
/// genera escenas siguiendo condiciones
/// ubica la esfera en una posicion que  metemos en unity
/// introduce aleatoriedad en posicion de origen y cantidad
/// añade fisicas al generar esferas
/// gestiona el ciclo de vida de las esferas
/// </summary>
public class M_BallsSpawn_fran : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("Valores editables")]
    [SerializeField]
    [Range(1, 300)]
    int totalSpheresToCreate = 1;

    //Añadi una variable que me permita definir un rango horizontal y de profundidad
    [SerializeField]
    [Range(1, 15)]
    float horizontalXRange = 2;

    [SerializeField]
    [Range(1, 15)]
    float horizontalZRange = 2;

    [Header("Referencias externas")]

    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    Transform spawnOrigin;
    #endregion

    #region METHODS
    private void Start()
    {
        //genera una esfera x veces segun el contador 
        for (int i = 0; i < totalSpheresToCreate; ++i)
        {
            GneratePrefabAtRandomOrigin();
        }
    }







    void GneratePrefabAtRandomOrigin()
    {
        Vector3 newRandomPosition = new Vector3
            (
            Random.Range(-horizontalXRange, horizontalXRange), 5, Random.Range(-horizontalZRange, horizontalZRange)
            );
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = newRandomPosition;
 


    }
    void GeneratePrefabAtCustomOrigin(int num)
    {
        //generar una instancia del prefab
        num = num +1;
        GameObject newBall = Instantiate(ballPrefab);
        newBall.name = "NuevaEsferaTemporal" +num;
        newBall.tag = "Coin";
        newBall.layer = 6;
        newBall.transform.position = spawnOrigin.position;
    }

    #endregion
}
