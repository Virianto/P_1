using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
///crear 4camaras 
///camara 1 uso personal
///camara 2 igual pero mcon sacudidas
///camara 3 que siga al avion desde mas lejos con pequeñas vibraciones
///cmara  4 primera persona
/// </summary>
public class M_CamarasAvion : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]

    List<CinemachineCamera> allVirtualCamerasList = new();

    [SerializeField]
    KeyCode firstCameraKey = KeyCode.Alpha1;

    [SerializeField]
    KeyCode secondCameaKey = KeyCode.Alpha2;

    [SerializeField]
    KeyCode tertiaryCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode cuartiaryCameraKey = KeyCode.Alpha4;

    int _currentActiveCameraIndex = 0;

    public int CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }

        set
        {
            _currentActiveCameraIndex = value;
            SwichToCinemachineCamera();
        }
    }

    #endregion


    #region METHODS 

    private void Update()
    {
        if (Input.GetKeyDown(firstCameraKey))
        {
            CurrentActiveCameraIndex = 0;
        }

        if (Input.GetKeyDown(secondCameaKey))
        {
            CurrentActiveCameraIndex = 1;
        }

        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }
        if (Input.GetKeyDown(cuartiaryCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
    }

    void SwichToCinemachineCamera()
    {
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i == CurrentActiveCameraIndex)

            {
                allVirtualCamerasList[i].Priority = 1;
            }
            else
            {
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }
    #endregion
    }
