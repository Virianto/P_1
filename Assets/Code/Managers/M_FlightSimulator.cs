using Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Referencia al canvas del juego
/// Referencia al player de la escena
/// Variable de tiempo para crono
/// </summary>
public class M_FlightSimulator : Singleton<M_FlightSimulator>
{
    #region ATTRIBUTES

    [SerializeField]
    UI_FlightSimulatorCanvas flightSimulatorCanvas;

    [SerializeField]
    B_PlayerPlane player;

    [SerializeField]
    [Range(5, 60)]
    float gameTimeLeft = 10;

    public event Action<float> OnTimeLeftChanged;
    public event Action<float> OnPlayerLifeLeftChanged;

    #endregion

    #region METHODS

    private void Update()
    {
        gameTimeLeft -= Time.deltaTime;
        OnTimeLeftChanged?.Invoke(gameTimeLeft); //Invokar a los métodos suscritos
    }

    ///// <summary>
    ///// método con gestión de tiempo para dañar al jugador
    ///// </summary>
    ///// <param name="player">jugador al que afecta</param>
    ///// <returns></returns>
    //IEnumerator HurtPlayer(B_CharacterController player)
    //{
    //    //Dañar al jugador
    //    player.TakeDamage(trapDamage);

    //    Debug.Log("Dañar al jugador antes de la espera");
    //    Debug.Log($"Se llama {player.name}");

    //    yield return new WaitForSeconds(trapFrequencyDamage);

    //    //Comprobar si el jugador sigue estando dentro
    //    if (playerIsInsideArea)
    //    {
    //        //Volver a llamar a esta subrutina
    //        StartCoroutine(HurtPlayer(player));
    //    }

    //    Debug.Log("Ya ha pasado la esperas, hacer otra cosa");
    //    Debug.Log($"Sigue llamandose {player.name}");
    //}

    public void PlayerLifeChanged(float playerLifeLeft)
    {
        OnPlayerLifeLeftChanged?.Invoke(playerLifeLeft);
    }

    public void NewCoinCollected()
    {
        flightSimulatorCanvas.UpdateCounter(player.totalYellowCoinsCollected);
    }

    void LaunchGameOver()
    {

    }

    #endregion
}
