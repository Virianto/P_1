using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proosito de esta clase
/// </summary>
public class RadioController : MonoBehaviour
{
    #region ATTRIBUTES
    public AudioSource audioSource;
    public AudioClip[] canciones; // Aquí meterás todas tus pistas
    private int indiceActual = 0;

    #endregion


    #region METHODS 
    void Start()
    {
    }

    void Update()
    {
        // Si la canción terminó y no está en pausa, pasa a la siguiente automáticamente
        if (!audioSource.isPlaying && audioSource.time == 0 && canciones.Length > 0)
        {
            SiguienteCancion();
        }
    }

    public void ReproducirCancion(int indice)
    {
        audioSource.clip = canciones[indice];
        audioSource.Play();
    }

    public void SiguienteCancion()
    {
        indiceActual = (indiceActual + 1) % canciones.Length; // Vuelve a 0 al llegar al final
        ReproducirCancion(indiceActual);
    }

    public void AlternarPausa()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    #endregion
}
