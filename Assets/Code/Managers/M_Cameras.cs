using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Detectar Input de usuario para saltar de una cámara a otra
/// </summary>
public class M_Cameras : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha0;

    [SerializeField]
    KeyCode secondCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha2;

    int currentActiveCameraIndex = 0;

    #endregion

    #region METHODS

    void Update()
    {        
        if (Input.GetKeyDown(firstCameraKey)) 
        {
            SwitchToCinemachineCamera(0);
        }
        if (Input.GetKeyDown(secondCameraKey))
        {
            SwitchToCinemachineCamera(1);
        }
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            SwitchToCinemachineCamera(2);
        }
    }

    void SwitchToCinemachineCamera(int newIndex)
    {
        // Recorrer la lista entera de cinemachine cameras
        for(int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if(i == newIndex)
            {
                // Para cada cámara, si es la del índice que quiero, le cambio la priroridad a 1
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                // Para cada cámara, si NO es la que quiero, le cambio la prioridad a 0
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }

    #endregion
}
