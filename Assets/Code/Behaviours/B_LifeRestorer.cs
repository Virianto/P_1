using UnityEngine;

public class B_LifeRestorer : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] int lifeToRestore = 5;
    #endregion

    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<B_CharacterController2>().RestoreLife(lifeToRestore);
        gameObject.SetActive(false);
    }

    #endregion
}
