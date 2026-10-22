using UnityEditor;
using UnityEngine;

public class B_Coin : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObject coinBody;

    
    public bool superCoin = false;

    [SerializeField]
    Renderer coinRenderer;

    #endregion

    #region METHODS

    private void Start()
    {
        if (superCoin == true)
        {
            coinRenderer.material.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (superCoin == true)
        {
            coinParticles.Emit(1000);
        }
        // Reproducir sonido de recolección
        coinAudiosource.PlayOneShot(coinAudiosource.clip);
        // Va a emitir unas partículas de despedida
        coinParticles.Emit(50);
        // Desactivar el sphereCollider para prevenir más recogidas de la misma moneda
        GetComponent<Collider>().enabled = false;
        // Desactivar el hijo para que el jugador deje de ver la moneda
        coinBody.SetActive(false);

        
    }

    #endregion
}
