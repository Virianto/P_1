
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// asignar una camara con la extension dolly 
/// controlar l aveloicidad de la camara
/// movimiento de vaiven a lo largo del spline container
/// </summary>
public class camera_pinpon : MonoBehaviour
{
    #region ATTRIBUTES
    CinemachineSplineDolly c_splineDolly;
    [SerializeField]
    [Range(0, 1)]
    float camSpeed = 0.2f;
    #endregion

    #region METHODS
    private void OnEnable()
    {
        c_splineDolly = GetComponent<CinemachineSplineDolly>();
        c_splineDolly
    }
    #endregion
}
