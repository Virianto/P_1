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


    M_RingManager myManager;
    #endregion


    #region METHODS


    public void InitializeRing(M_RingManager manager, Vector3 newPosition, float newLifeTime, float newScale, RingModificationType newType)
    {
        ringType = newType;
        myManager = manager;
        transform.position = newPosition;
        this.lifeTime = newLifeTime;
        transform.localScale = new Vector3 (newScale, newScale, newScale);

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
            }

            if (ringType == RingModificationType.Speed)
            {
                player.speed += 5;
               M_FlightSimulator.Instance.PlayerSpeedChanged(player.speed);
               M_FlightScoolCameraManager.Instance.ChangeToHitCamera(3);

            }
            if (ringType == RingModificationType.Score)
            {
                M_FlightSimulator.Instance.EarnPoints(1); 
                
            }
            if (ringType == RingModificationType.Time)
            {
                
                M_FlightSimulator.Instance.ModifyGameplayTime(5);
            }


        }

    }


    #endregion
}
