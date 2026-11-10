using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RingType
{
    speed,
    points,
    life,
    time
}

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_HoveringRing : MonoBehaviour
{
    #region ATTRIBUTES

    M_RingsManager ringsManager;

    B_PlayerPlane player;

    public RingType ringType;

    public float minLifeTime = 20;
    public float maxLifeTime = 30;

    [SerializeField]
    List<Color> ringTypeColorList = new();

    #endregion





    #region METHODS

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeRing(M_RingsManager manager, Vector3 newPosition)
    {
        // Referencia al Manager
        ringsManager = manager;

        // Referencia a la posición de creación
        transform.position = newPosition;

        // Tipo de anillo creado
        int randomTypeIndex = Random.Range(0, 4);
        ringType = (RingType)randomTypeIndex;

        // Color del anillo
        ChangeRingColor();

        StartCoroutine(FinishLifeCycle());
    }

    /// <summary>
    /// Gestionar el ciclo de vida de las monedas
    /// </summary>
    IEnumerator FinishLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en Initialize (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en Initialize (donde hemos metido la corutina)

        ringsManager.FinishRingLifeCycle(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<B_PlayerPlane>();

        if (player != null)
        {
            if (ringType == RingType.speed)
            {
                player.ModifySpeed(10);
                M_FlightCameras.Instance.ChangeCamera(2);
            }

            else if (ringType == RingType.points)
            {
                player.ModifyPoints(10);
            }

            else if (ringType == RingType.life)
            {
                player.ModifyLife(-10);
                M_FlightCameras.Instance.ChangeCamera(1);
            }

            else if (ringType == RingType.time)
            {
                M_FlightSimulator.Instance.ModifyTime(10);
            }

            ringsManager.FinishRingLifeCycle(this);
        }
    }

    /// <summary>
    /// Cambiar el color del prefab del anillo según el tipo que sea
    /// </summary>
    void ChangeRingColor()
    {
        // Buscar y almacenar todos los Renderer del objeto
        // * Crear una variable donde guardar las referencias
        // * Buscar todas las referencias en la jerarquía
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        // Recorrer la variable con las referencias
        for (int i = 0; i < allRingRenderers.Length; ++i)
        {
            // Cambiar el color de cada elemento según el tipo
            // * Acceder al elemento de la posición "i"
            // * Buscar el material y el color
            // * Convertir el color según el tipo de anillo (con un parseo)
            allRingRenderers[i].material.color = ringTypeColorList[(int)ringType];
        }
    }

    #endregion
}