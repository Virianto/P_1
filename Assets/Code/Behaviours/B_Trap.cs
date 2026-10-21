using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class B_Trap : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    [Range(0,10)]
    int TrapDamage =1;

    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;

    bool playerIsInsideArea = false;

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        StartCoroutine(HurtPlayer());
    }

    private void OnTriggerExit(Collider other)
    { 
    }
        IEnumerator HurtPlayer()
    {
        playerIsInsideArea = false;
        Debug.Log("Dañar");
          yield return new WaitForSeconds (trapFrequencyDamage);
    }
    #endregion
}
