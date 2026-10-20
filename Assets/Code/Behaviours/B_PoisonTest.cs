using UnityEngine;

public class B_PoisonTest : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    ParticleSystem poisonPS;


    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<B_CharacterController>())
        {
            poisonPS.Emit(250);
        }
    }

    #endregion
}
