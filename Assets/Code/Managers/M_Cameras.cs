using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// * Tener referencias a TODAS las cámaras virtuales (cinemachine) de la escena
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
    KeyCode thirdCameraKey = KeyCode.Alpha2;


    int currentActiveCameraIndex = 0;

    #endregion


    #region METHODS


    private void Update()
    {
        if (Input.GetKeyDown(firstCameraKey))
        {
            SwitchToCinemachineCamera(0);
        }

        if (Input.GetKeyDown(secondCameraKey))
        {
            SwitchToCinemachineCamera(1);
        }

        if (Input.GetKeyDown(thirdCameraKey))
        {
            SwitchToCinemachineCamera(2);
        }
    }

    void SwitchToCinemachineCamera(int newIndex)
    {
        //Recorrer la lista entera de cinemachine cameras

        for (int a = 0; a < allVirtualCamerasList.Count; a++) 
        {
            
            if(a == newIndex)
            {
                //Para cada cámara, si es la del índice que quiero le cambio la prioiridad a 1
                allVirtualCamerasList[a].Priority = 1;
            }
            else
            {
                //para cada cámara, si No es la que quiero, le cambio la prioridad a 0,
                allVirtualCamerasList[a].Priority = 0;
            }


        }

    }

    #endregion
}
