using UnityEngine;

/// <summary>
/// X Hacer q los anillos sean prefabs
/// Tiene q gestionar todos los anillos y:
/// - Crear una instancia cada x anillos (editable)
/// - que tipo de anillo sera
/// - al invocar el método "InitializeRing()" se indicará
///     - Tipo (enum)
///     - Rotación aleatoria (en un rango)
///     - Color, escala
///     - Tiempo de vida (3-10 seg)
///     - Referencia al propio manager
/// - Cada anillo al detectar al jugador en su OnTriggerEnter, lanzará un método y otro según el tipo de anillo q sea (si es de vida lanza el método de vida, etc)
/// </summary>
public class B_HoveringRing : MonoBehaviour
{
    #region ATTRIBUTES
    #region ATTRIBUTES
    [Header("VALORES EDITABLES")]
    [SerializeField]
    [Range(1, 300)]
    int totalRingsToCreate = 1;

    // Variable q me permita definir un rango horizontal (X)
    [SerializeField]
    [Range(1, 60)]
    float horizontalXRange = 10;

    // Variable q me permita definir un rango de profundidad (Y)
    [SerializeField]
    [Range(1, 60)]
    float verticalYRange = 10;

    // Variable q me permita definir un rango de profundidad (Z)
    [SerializeField]
    [Range(1, 60)]
    float horizontalZRange = 10;

    [SerializeField]
    [Range(1, 30)]
    float ringLifeTime = 10;

    [SerializeField]
    [Range(1, 60)]
    float timeBetweenRings = 5;

    [Space(10)]

    [Header("REFERENCIAS EXTERNAS")]
    [SerializeField]
    GameObject ringPrefab;

    #endregion


    #region METHODS


    #endregion
}
