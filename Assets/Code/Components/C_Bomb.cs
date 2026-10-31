using System.Collections;
using UnityEngine;

public class C_Bomb : MonoBehaviour
{
    #region ATTRIBUTES

    M_CoinsManager MyManager;

    public float minLifeTime = 5;
    public float maxLifeTime = 15;

    [SerializeField]
    AudioSource bombAudiosource;

    [SerializeField]
    AudioSource damageAudiosource;

    [SerializeField]
    ParticleSystem bombParticles;

    [SerializeField]
    GameObject bombBody;
    public int heartLifeUp = -5;

    #endregion





    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        bombAudiosource.PlayOneShot(bombAudiosource.clip);
        damageAudiosource.Play();
        
        bombParticles.Emit(50);

        GetComponent<Collider>().enabled = false;

        bombBody.SetActive(false);
    }

    /// <summary>
    /// Aplicar modificaciones y guardar referencias
    /// </summary>
    /// <param name="manager"> Referencia al Manager que creó esta instancia </param>
    /// <param name="newPosition"> Nueva posición en la que ubicar el objeto </param>
    public void InitializeBomb(M_CoinsManager manager, Vector3 newPosition)
    {
        MyManager = manager;
        transform.position = newPosition;

        StartCoroutine(FinishBombLifeCycle());
    }

    /// <summary>
    /// Gestionar el ciclo de vida de las supermonedas
    /// </summary>
    IEnumerator FinishBombLifeCycle()
    {
        // Si escribimos código aquí SÍ es relevante el orden en InitializeBall (donde hemos metido la corutina)

        yield return new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        // Si escribimos código aquí NO es relevante el orden en InitializeBall (donde hemos metido la corutina)

        MyManager.FinishBombLifeCycle(this);
    }

    #endregion
}
