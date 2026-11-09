using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// X Hacer q los anillos sean prefabs
/// Tiene q gestionar todos los anillos y:
/// - Crear una instancia cada x segundos (editable)
/// - Decidir que tipo de anillo sera al invocar el método "InitializeRing()" del B_HoveringRing se indicará:
///     - Tipo (enum)
///     X Rotación aleatoria (en un rango)
///     X Posición aleatoria (en un rango)
///     - Color (escala, material, etc)
///     X Tiempo de vida (3-10 seg)
///     X Referencia al propio manager
/// - Cada anillo al detectar al jugador en su OnTriggerEnter, lanzará un método y otro según el tipo de anillo q sea (si es de vida lanza el método de vida, etc)
/// </summary>
public class M_Rings : MonoBehaviour
{
    #region ATTRIBUTES


    #endregion
    [Header("VALORES EDITABLES")]
    [SerializeField]
    [Range(1, 100)]
    int totalRingsToCreate = 1;

    // Variable q me permita definir un rango horizontal (X)
    [SerializeField]
    [Range(1, 100)]
    float horizontalXRange = 10;

    // Variable q me permita definir un rango de profundidad (Y)
    [SerializeField]
    [Range(1, 100)]
    float verticalYRange = 10;

    // Variable q me permita definir un rango de profundidad (Z)
    [SerializeField]
    [Range(1, 100)]
    float horizontalZRange = 10;

    [SerializeField]
    [Range(1, 30)]
    public float ringLifeTime = 10;

    [SerializeField]
    [Range(1, 60)]
    float timeBetweenRings = 5;
    [Space(10)]

    [Header("REFERENCIAS EXTERNAS")]
    [SerializeField]
    GameObject ringPrefab;

    [SerializeField]
    Transform point1;

    List<B_HoveringRing>allInstantiateRingsList = new();

    #region METHODS
    private void Start()
    {
        StartCoroutine(StartRingLifeCycle());
    }

    public IEnumerator StartRingLifeCycle()
    {
        // Genero un anillo el numero de veces indicado
        for (int i = 0; i < totalRingsToCreate; i++)
        {
            Vector3 newRandomPosition = new Vector3(Random.Range(-horizontalXRange, horizontalXRange), Random.Range(-verticalYRange, verticalYRange), Random.Range(-horizontalZRange, horizontalZRange));
            GenerateNewPrefabRing(point1.position + newRandomPosition);

            yield return new WaitForSeconds(timeBetweenRings);
        }
    }

    void GenerateNewPrefabRing(Vector3 newPosition)
    {
        B_HoveringRing newRing = Instantiate(ringPrefab).GetComponent<B_HoveringRing>();
        allInstantiateRingsList.Add(newRing);
        newRing.InitializeRing(this, newPosition/*, Random.value * 10*/);
    }

    public void FinishRingLifeCycle(B_HoveringRing ring)
    {
        // Elimino el anillo de mi lista
        allInstantiateRingsList.Remove(ring);
        // Luego destruyo el objeto
        Destroy(ring.gameObject);
    }

    #endregion
}
