using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Anillo
/// </summary>
public class B_HoveringRing : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    GameObject ringPrefab;

    M_Rings ringsManager;

    public enum RingType
    {
        life,
        time,
        speed,
        points
    }

    public RingType ringType;

    bool ringIsActive;

    // Lista de distintos colores, a introducir desde Unity
    [SerializeField]
    List<Color> ringTypeColorsList = new();

    #endregion

    #region METHODS
    public void InitializeRing(M_Rings manager, Vector3 spawnPosition)
    {
        ringsManager = manager;
        transform.position = spawnPosition;

        int randomTypeIndex = Random.Range(0, 4);
        //RingType randomTypeIndex = (RingType)(Random.Range, 0, 4);

        ringType = (RingType)randomTypeIndex;
        
        ringIsActive = true;

        ChangeRingColor();

        StartCoroutine(FinishLifeCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponentInParent<B_PlayerPlane>();

        if (ringType == RingType.life)
        {
            player.ModifyLife(-2);

            M_CamerasFlight.Instance.ChangeCamera(1);
        }
        else if (ringType == RingType.time)
        {
            M_FlightSimulator.Instance.ModifyTime(10);
        }
        else if (ringType == RingType.speed)
        {
            player.ModifySpeed(5);

            M_CamerasFlight.Instance.ChangeCamera(2);
        }
        else if (ringType == RingType.points)
        {
            M_FlightSimulator.Instance.ModifyPoints(1);
        }

        if(player != null)
        {
            ringsManager.FinishRingLifeCycle(this);
        }
    }

    void ChangeRingColor()
    {
        // 1. Busco y almaceno todos los renders del objeto
        //  - Creo una variable donde guardo las referencias
        //  - Busco esas referencias en la jerarquía
        Renderer[] allRingsRenderers = GetComponentsInChildren<Renderer>();
        // 2. Recorro la variable con la referencia
        for (int r = 0; r < allRingsRenderers.Length; ++r)
        {
            // 3. Cambio color de cada elemento según el tipo
            // - Accedo a la posición 'r'
            // - Busco el material y el color
            // - Convierto el color según el tipo de anillo (con un parseo)
            allRingsRenderers[r].material.color = ringTypeColorsList[(int)ringType];
        }
    }

    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(ringsManager.ringLifeTime);
        // Solamente elimino el anillo si aún no ha sido activado por el jugador
        if (ringIsActive)
        {
            ringsManager.FinishRingLifeCycle(this);
        }
    }

    #endregion
}
