using UnityEngine;

public enum PlatformColor
{
    YellowPlatform,
    BluePlatform,
    GreenPlatform
}

public class B_ColorControlPlatform : MonoBehaviour
{
    #region ATTRIBUTES

    public PlatformColor platformColor;

    B_CharacterController player;

    [SerializeField]
    KeyCode changeColorKey = KeyCode.Y;

    bool playerCanChangeColor = false;

    #endregion

    #region METHODS
        
    void OnTriggerEnter(Collider other)
    {
        playerCanChangeColor = true;
        player = other.GetComponent<B_CharacterController>();
    }

    void Update()
    {
        // ¡OJO! Si pulso la tecla que no es (o que espera OTRA plataforma) dará error
        if (Input.GetKeyDown(changeColorKey))
        {
            // Creo un método propio que haga ese cambio y lo invoco solamente si se puede
            if (playerCanChangeColor)
            {
                ChangePlayerColor();
            }            
        }
    }

    void OnTriggerExit(Collider other)
    {
        playerCanChangeColor = false;
    }

    void ChangePlayerColor()
    {
        // CASO 1: Cambios para AMARILLO
        if (platformColor == PlatformColor.YellowPlatform)
        {
            // Modifica el permiso del jugador
            // player.canCollectYellowCoins = true;

            // player.canCollectBlueCoins = false;
            // player.canCollectGreenCoins = false;
        }

        // CASO 2: Cambios para AZUL
        if (platformColor == PlatformColor.BluePlatform)
        {
            // Modifica el permiso del jugador
            // player.canCollectBlueCoins = true;

            // player.canCollectYellowCoins = false;
            // player.canCollectGreenCoins = false;
        }

        // CASO 3: Cambios para VERDE
        if (platformColor == PlatformColor.GreenPlatform)
        {
            // Modifica el permiso del jugador
            // player.canCollectGreenCoins = true;

            // player.canCollectBlueCoins = false;
            // player.canCollectYellowCoins = false;
        }

        player.GetComponentInChildren<Renderer>().material = gameObject.GetComponent<Renderer>().material;
    }

    #endregion
}
