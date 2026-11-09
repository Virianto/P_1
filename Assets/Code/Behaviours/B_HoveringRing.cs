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

        Renderer[] allRingsRenderers = GetComponentsInChildren<Renderer>();
        for (int r = 0; r < allRingsRenderers.Length; ++r)
        {
            allRingsRenderers[r].material.color = ringTypeColorsList[(int)ringType];
        }
        StartCoroutine(FinishLifeCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ringType == RingType.life)
        {
            B_PlayerPlane vida = other.GetComponentInParent<B_PlayerPlane>();
            vida.ModifyLife(-2);

            M_CamerasFlight.Instance.ChangeCamera(1);
        }
        else if (ringType == RingType.time)
        {
            M_FlightSimulator.Instance.ModifyTime(5);
        }
        else if (ringType == RingType.speed)
        {
            B_PlayerPlane velocidad = other.GetComponentInParent<B_PlayerPlane>();
            velocidad.ModifySpeed(5);

            M_CamerasFlight.Instance.ChangeCamera(2);
        }
        else if (ringType == RingType.points)
        {
            M_FlightSimulator.Instance.ModifyPoints(1);
        }
    }

    IEnumerator FinishLifeCycle()
    {
        yield return new WaitForSeconds(ringsManager.ringLifeTime);
        ringsManager.FinishRingLifeCycle(this);
    }

    #endregion
}
