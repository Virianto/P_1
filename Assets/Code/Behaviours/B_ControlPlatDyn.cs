using UnityEngine;

/// <summary>
/// Control de plataformas para activar obstaculos dinamicos
/// </summary>
public class B_ControlPlatformDyn : MonoBehaviour
{
    //Referencia persistente a mi gestor de escena/juego
    public M_GameManager gameManager;

    public GameObject trapObj, trapObj2, trapObj3;

    //Detectar cuando ha entrado el jugador
    //Habilitar el botón para desactivar trampa
    //Vincular la trampa que controla esta plataforma con el OnClick del botón

    //Detectar cuándo ha salido el jugador
    //Deshabilito el botón
    //DesVincular la trampa que controla esta plataforma con el OnClick del botón

    private void OnTriggerEnter(Collider other)
    {
        if (trapObj != null)
            gameManager.EnableTrapButton(gameObject, trapObj);
        if (trapObj2 != null)
            gameManager.EnableTrapButton(gameObject, trapObj2);
        if (trapObj3 != null)
            gameManager.EnableTrapButton(gameObject, trapObj3);
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }
}
