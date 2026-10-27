using UnityEngine;

public class B_ControlPlatform : MonoBehaviour
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
        if (trapObj3 is not null) {
			gameManager.EnableTrapButton(gameObject, trapObj);
            gameManager.EnableTrapButton(gameObject, trapObj2);
			gameManager.EnableTrapButton(gameObject, trapObj3);
		}
        else if (trapObj2 is not null) {
            gameManager.EnableTrapButton(gameObject, trapObj);
            gameManager.EnableTrapButton(gameObject, trapObj2);
        } else {
            gameManager.EnableTrapButton(gameObject, trapObj);
            //gameManager.EnableTrapButton(gameObject, trapObj2);
            //gameManager.EnableTrapButton(gameObject, trapObj3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.DisableTrapButton();
    }
}
