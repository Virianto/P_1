using Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class M_FlightSim : Singleton<M_FlightSim>
{
    public event Action<float> OnTimeLeftChange;
    public event Action<int> OnPointsChange;
    public event Action<float> OnPlayerLifeLeftChanged;

    [SerializeField] Ui_PlaneCanvas UiPlaneCanvas;
    [SerializeField] EthanPlaneController planeController;
    [SerializeField] [Range(5, 180)] float gameTime;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject GameOverHUD;
    public int playerPoints;
    public float playerLife;

    [SerializeField] List<CinemachineCamera> allVirtualCamerasList = new();
    int _currentActiveCameraIndex = 0;

    void Update()
    {
        gameTime -= Time.deltaTime;
        OnTimeLeftChange?.Invoke(gameTime);
        if (playerLife <= 0)
        {
            HUD.SetActive(false);
            GameOverHUD.SetActive(true);
            planeController.enabled = false;
        }
    }


    #region PLAYER GAMEPLAY
    //------------------------------Change Cam----------------------------------
    #region CAMERA VALUE
    public int _CurrentActiveCameraIndex
    {
        get { return _currentActiveCameraIndex; }
        set
        {
            _currentActiveCameraIndex = value;
            SwitchToCinemachineCam(_currentActiveCameraIndex);
        }
    }
    void SwitchToCinemachineCam(int newIndex)
    {
        Debug.Log(newIndex + " cam");
        for (int i = 0; i < allVirtualCamerasList.Count; ++i)
        {
            if (i == newIndex)
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
    public void ChangeCam(int newIndex)
    {
        StartCoroutine(SwitchCamCourutine(newIndex));
    }

    IEnumerator SwitchCamCourutine(int newIndex)
    {
        _CurrentActiveCameraIndex = newIndex;
        yield return new WaitForSeconds(3f);
        _CurrentActiveCameraIndex = 0;
    }

    //-----------------------------Player life----------------------------------
    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLife -= playerLifeLeft);
    }
    //-----------------------------Red Screen-----------------------------------
    public void RedSceen()
    {
        StartCoroutine(RedSceenCourutine());
    }

    IEnumerator RedSceenCourutine()
    {
        UiPlaneCanvas.ShowRedScreen(true);
        yield return new WaitForSeconds(3f);
        UiPlaneCanvas.ShowRedScreen(false);
    }

    //----------------------------Update Points----------------------------------
    public void UpdatePoints(int newAmount)
    {
        OnPointsChange?.Invoke(playerPoints += newAmount);
    }

    //------------------------Change Speed and Cam-------------------------------
    public void ChangeSpeed(int newIndex)
    {
        StartCoroutine(SwitchSpeedCourutine(newIndex));
    }

    IEnumerator SwitchSpeedCourutine(int newIndex)
    {
        _CurrentActiveCameraIndex = 2;
        planeController.planeSpeed = newIndex;
        yield return new WaitForSeconds(5f);
        planeController.planeSpeed = 5;
        _CurrentActiveCameraIndex = 0;
    }
 
    #endregion
}
