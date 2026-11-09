
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
    
    public float lifeTime = 7;

    RingModificationType ringType;

    //Color rojo = resta vida, Color azul = suma vida, Color amarillo = suma puntos, Color verde = suma tiempo
    [SerializeField]
    List<Color> RingColorList = new();


    M_RingManager myManager;
    #endregion


    #region METHODS


    public void InitializeRing(M_RingManager manager, Vector3 newPosition, float newLifeTime, float newScale, RingModificationType newType, Color newColor)
    {
        ringType = newType;
        myManager = manager;
        transform.position = newPosition;
        this.lifeTime = newLifeTime;
        ColorRing(newColor);
        transform.localScale = new Vector3 (newScale, newScale, newScale);

        
        //StartCoroutine(FinishLifeCycle());

    }
    void OnTriggerEnter(Collider other)
    {
        B_PlayerPlane player = other.GetComponentInParent<B_PlayerPlane>();
        if (player != null)
        {
            if (ringType == RingModificationType.Life)
            {
                player.currentPlayerLife += -1;
              M_FlightSimulator.Instance.PlayerLifeChanged(player.currentPlayerLife / player.maxPlayerLife);
              M_FlightScoolCameraManager.Instance.ChangeToHitCamera(1);
                myManager.FinishRingLifeCycle(this);
            }

            if (ringType == RingModificationType.Speed)
            {
                player.speed += 5;
               M_FlightSimulator.Instance.PlayerSpeedChanged(player.speed);
               M_FlightScoolCameraManager.Instance.ChangeToHitCamera(3);
                myManager.FinishRingLifeCycle(this);

            }
            if (ringType == RingModificationType.Score)
            {
                M_FlightSimulator.Instance.EarnPoints(1);
                myManager.FinishRingLifeCycle(this);

            }
            if (ringType == RingModificationType.Time)
            {
                
                M_FlightSimulator.Instance.ModifyGameplayTime(5);
                myManager.FinishRingLifeCycle(this);
            }


        }

    }


    void ColorRing(Color newColor)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = newColor;
        }
    }



    //}

    //IEnumerator FinishLifeCycle()
    //{
    //    yield return new WaitForSeconds(lifeTime);
    //    myManager.FinishRingLifeCycle(this);
    //}


    #endregion
}
