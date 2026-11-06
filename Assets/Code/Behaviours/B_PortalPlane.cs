using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>

public class B_PortalPlane : MonoBehaviour
{
    #region ATTRIBUTES

    B_PlayerPlane playerPlane;
    [SerializeField]
    [Range(20, 100)]
    float speed = 50;

    #endregion
    #region METHODS

    public void SpeedPortal()
    {
        playerPlane.CurrentSpeed(speed);
    }
    public void PointsPortal()
    {
        
    }

   #endregion    
}

