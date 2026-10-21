using Unity.VisualScripting;
using UnityEngine;

public class B_Heart : MonoBehaviour
{

    [SerializeField]
    AudioSource coinAudiosource;

    [SerializeField]
    ParticleSystem coinParticles;

    [SerializeField]
    GameObject coinBody;
    public int heartLifeUp = 5;


    void OnTriggerEnter(Collider other)
    {
        coinAudiosource.PlayOneShot(coinAudiosource.clip);

        coinParticles.Emit(50);

        GetComponent<Collider>().enabled = false;

        coinBody.SetActive(false);


    }

  
}

