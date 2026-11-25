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
    public event Action<float> OnPlayerSpeedChanged;

    [SerializeField] Ui_PlaneCanvas UiPlaneCanvas;
    [SerializeField] EthanPlaneController planeController;
    [SerializeField] [Range(5, 180)] float gameTime;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject GameOverHUD;
    public int playerPoints;
    public float playerLife;
    private Coroutine speedCoroutine;

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
        _CurrentActiveCameraIndex = newIndex;
    }

    //--------------------Player life and Red Screen----------------------------
    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLife -= playerLifeLeft);
        StartCoroutine(RedSceenCourutine());
    }

    IEnumerator RedSceenCourutine()
    {
        _CurrentActiveCameraIndex = 1;
        UiPlaneCanvas.ShowRedScreen(true);
        yield return new WaitForSeconds(3f);
        UiPlaneCanvas.ShowRedScreen(false);
        _CurrentActiveCameraIndex = 0;
    }

    //----------------------------Update Points----------------------------------
    public void UpdatePoints(int newAmount)
    {
        OnPointsChange?.Invoke(playerPoints += newAmount);
    }

    //------------------------Change Speed and Cam-------------------------------
    public void ChangeSpeed(float boost)
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        // Start the new one and save its reference
        speedCoroutine = StartCoroutine(SwitchSpeedCourutine(boost));
    }

    public IEnumerator SwitchSpeedCourutine(float boost)
    {
        planeController.boost = true;
        planeController.OnBoostAction(boost);
        yield return new WaitForSeconds(5f);
        planeController.boost = false;
        planeController.OnBoostAction(50);
        speedCoroutine = null;
    }

    public void StopSpeedCoroutine()
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
            speedCoroutine = null;
        }
    }

    #endregion
}
