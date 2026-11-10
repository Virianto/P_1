using System.Collections;
using UnityEngine;

/// <summary>
/// X Instanciar un prefab de anillo en algún punto aleatorio de la escena
/// X Indicar a ese anillo de qué tipo es para que se inicialice
/// X Gestionar el ciclo de vida del anillo
/// </summary>
public class M_Rings : MonoBehaviour
{
    #region ATTRIBUTES

    [Header("EXTERNAL REFERENCES")]

    [SerializeField]
    GameObject ringPrefab;

    [Header("EDITABLE VALUES")]

    [SerializeField]
    [Range(1, 30)]
    float horizontalRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float depthRandomLimit = 5;

    [SerializeField]
    [Range(1, 30)]
    float verticalRandomLimit = 10;

    [SerializeField]
    [Range(1, 7)]
    float timeBetweenRingGen = 4;

    #endregion

    #region METHODS

    void Start()
    {
        StartCoroutine(GenerateRingRoutine());
    }

    IEnumerator GenerateRingRoutine()
    {
        GenerateNewRandomRing();
        yield return new WaitForSeconds(timeBetweenRingGen);        
        StartCoroutine(GenerateRingRoutine());
    }

    void GenerateNewRandomRing()
    {
        // Invento un punto aleatorio de la escena para el nuevo anillo
        Vector3 newRingPos = new Vector3(
            Random.Range(-horizontalRandomLimit, horizontalRandomLimit),
            Random.Range(-verticalRandomLimit, verticalRandomLimit),
            Random.Range(-depthRandomLimit, depthRandomLimit));

        // Decisión "al azar" de qué tipo asignar a mi futuro nuevo anillo:
        RingModificationType newRingType = (RingModificationType)Random.Range(0, 4);

        // Invento un tiempo de vida aleatorio para el nuevo anillo
        float ringLifeTime = Random.Range(3, 10);

        // Creamos un anillo nuevo en escena usando el prefab y nos quedamos su SCRIPT
        B_HoveringRing newRing = Instantiate(ringPrefab).GetComponent<B_HoveringRing>();

        newRing.InitializeRing(this, newRingType, newRingPos, ringLifeTime);
    }

    public void FinishRingLifeCycle(B_HoveringRing endingRing)
    {
        // Aquí meteríamos efectos de partículas, de sonido, animaciones y demás
        // antes de eliminar definitivamente el anillo

        // Quitamos el anillo de la escena
        Destroy(endingRing.gameObject);
    }

    #endregion
}
