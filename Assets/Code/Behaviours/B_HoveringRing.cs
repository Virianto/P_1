using System.Collections;
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


    public RingType ringType;

    M_RingsManager ringsManager;

    M_FlightSimulator flightManager;

    M_FlightCameras cameras;

    B_PlayerPlane player;

    public float minLifeTime = 10;
    public float maxLifeTime = 20;

    #endregion





    #region METHODS

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeRing(M_RingsManager manager, Vector3 newPosition)
    {
        ringsManager = manager;
        transform.position = newPosition;

        int randomTypeIndex = Random.Range(0, 4);
        ringType = (RingType)randomTypeIndex;

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
                flightManager.ModifyTime(10);
            }
        }
    }

    #endregion
}