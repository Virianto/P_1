using UnityEngine;

public class B_Corazon : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    AudioSource corazonSound;

    [SerializeField]
    ParticleSystem corazonParticles;

    [SerializeField]
    GameObject corazonBody;

    [SerializeField]
    [Range(0, 10)]
   public int corazonlife = 1;
    #endregion
    #region METHODS 

    void OnTriggerEnter(Collider other)
    {
        corazonSound.PlayOneShot(corazonSound.clip);

        corazonParticles.Emit(80);

        GetComponent<Collider>().enabled = false;

        corazonBody.SetActive(false);
    }
    #endregion
}
