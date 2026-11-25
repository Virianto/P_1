using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_RingsA : MonoBehaviour
{

    #region ATTRIBUTES

    [SerializeField]
    AudioSource ringAudioSource;

    [SerializeField]
    ParticleSystem ringParticles;

    [SerializeField]
    GameObject ringBody;

    #endregion


    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        ringAudioSource.PlayOneShot(ringAudioSource.clip);
        ringParticles.Emit(50);
    }

    #endregion
    }