using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
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

    [SerializeField]
    KeyCode fourthCameraKey = KeyCode.Alpha3;

    [SerializeField]
    KeyCode fifthCameraKey = KeyCode.Alpha4;

    [SerializeField]
    KeyCode sixthCameraKey = KeyCode.Alpha5;

    int _currentActiveCameraIndex = 0;
    private int CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }

        set 
        { 
            _currentActiveCameraIndex = value;
            SwicthToCinemachineCamera();
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
        if (Input.GetKeyDown(secondCameraKey))
        {
            CurrentActiveCameraIndex = 1;
        }
        if (Input.GetKeyDown(tertiaryCameraKey))
        {
            CurrentActiveCameraIndex = 2;
        }
        if (Input.GetKeyDown(fourthCameraKey))
        {
            CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(fifthCameraKey))
        {
            CurrentActiveCameraIndex = 4;
        }
        if (Input.GetKeyDown(sixthCameraKey))
        {
            CurrentActiveCameraIndex = 5;
        }
    }

    void SwicthToCinemachineCamera()
    {
        for (int i = 0; i < allVirtualCamerasList.Count; i++)
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

