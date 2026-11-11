using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class M_EthanCameras : MonoBehaviour
{

    [SerializeField] List<CinemachineCamera> allVirtualCamerasList = new();

    int _currentActiveCameraIndex = 0;
    public int _CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }
        set 
        {
            _currentActiveCameraIndex = value;
            SwitchToCinemachineCam(_currentActiveCameraIndex);
        }
    }

    [SerializeField] KeyCode _0CamKey = KeyCode.Alpha0;
    [SerializeField] KeyCode _1stCamKey = KeyCode.Alpha1;
    [SerializeField] KeyCode _2ndCamKey = KeyCode.Alpha2;
    [SerializeField] KeyCode _3rdCamKey = KeyCode.Alpha3;
    [SerializeField] KeyCode _4thCamKey = KeyCode.Alpha4;
    [SerializeField] KeyCode _5thCamKey = KeyCode.Alpha5;
    
    void Update()
    {
        if (Input.GetKeyDown(_0CamKey))
        {
            _CurrentActiveCameraIndex = 0;
        }
        if (Input.GetKeyDown(_1stCamKey))
        {
            _CurrentActiveCameraIndex = 1;
        }
        if (Input.GetKeyDown(_2ndCamKey))
        {
            _CurrentActiveCameraIndex = 2;
        }
        if (Input.GetKeyDown(_3rdCamKey))
        {
            _CurrentActiveCameraIndex = 3;
        }
        if (Input.GetKeyDown(_4thCamKey))
        {
            _CurrentActiveCameraIndex = 4;
        }
        if (Input.GetKeyDown(_5thCamKey))
        {
            _CurrentActiveCameraIndex = 5;
        }
    }

    public void SwitchToCinemachineCam(int newIndex)
    {
        Debug.Log(newIndex+" cam");
        for(int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if(i == newIndex)
            {
                allVirtualCamerasList[i].Priority = 1;  
            }
            else
            {
                allVirtualCamerasList[i].Priority = 0;
            }
        }
    }
    
}
