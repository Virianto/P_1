
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
/// 

public enum RingModificationType
{
    Life,
    Speed,
    Score,
    Time
}
public class B_HoveringRing : MonoBehaviour
{

    #region ATTRIBUTES

    public Vector3 spawnPoint = Vector3.zero;

    public bool ringIsActive = true;
   

    RingModificationType ringType;

    //Color rojo = resta vida, Color azul = suma vida, Color amarillo = suma puntos, Color verde = suma tiempo
    [SerializeField]
    List<Color> RingColorList = new();


    M_RingManager myManager;
    #endregion


    #region METHODS


    public void InitializeRing(M_RingManager manager, Vector3 newPosition, float newLifeTime, float newScale, RingModificationType newType)
    {
        ringType = newType;
        myManager = manager;
        transform.position = newPosition;
        transform.localScale = new Vector3(newScale, newScale, newScale);
        ChangeRingColor();
        

        
        StartCoroutine(FinishLifeCycle(newLifeTime));

    }
    void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponentInParent<B_PlayerPlane>();
        if (player != null)
        {
            if (ringType == RingModificationType.Life)
            {
                player.ModifyLifePoints(-1);
              M_FlightScoolCameraManager.Instance.ChangeToHitCamera(1);
                ringIsActive = false;
                myManager.FinishRingLifeCycle(this);
            }

            if (ringType == RingModificationType.Speed)
            {
                player.Accelerate(5);
               M_FlightScoolCameraManager.Instance.ChangeToHitCamera(3);
                ringIsActive = false;
                myManager.FinishRingLifeCycle(this);

            }
            if (ringType == RingModificationType.Score)
            {
                M_FlightSimulator.Instance.EarnPoints(1);
                ringIsActive = false;
                myManager.FinishRingLifeCycle(this);

            }
            if (ringType == RingModificationType.Time)
            {
                
                M_FlightSimulator.Instance.ModifyGameplayTime(5);
                ringIsActive = false;
                myManager.FinishRingLifeCycle(this);
            }


        }

    }


    //void ColorRing(Color newColor)
    //{
    //    foreach (Renderer r in GetComponentsInChildren<Renderer>())
    //    {
    //        r.material.color = newColor;
    //    }
    //}


    void ChangeRingColor()
    {
        
        Renderer[] allRingRenderers = GetComponentsInChildren<Renderer>();

        for (int i = 0; i < allRingRenderers.Length; i++) 
        {
            allRingRenderers[i].material.color = RingColorList[(int)ringType];
        }
    
    }
    IEnumerator FinishLifeCycle(float newLifeTime)
    {
        yield return new WaitForSeconds(newLifeTime);
        if (ringIsActive)
        {
            myManager.FinishRingLifeCycle(this);
        }
        
    }


    #endregion
}
