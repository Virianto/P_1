using System.Collections;
using UnityEngine;

public class LifeMoneyPlatform : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField] ParticleSystem rainMoney;
    [SerializeField][Range(1, 10)] float moneyFrequency;
    bool insideArea;
    #endregion

    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        rainMoney.Play();
        StartCoroutine(PlatformMoney(other.GetComponent<B_CharacterController2>()));
        insideArea = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        insideArea = false;
        rainMoney.Stop();
    }

    IEnumerator PlatformMoney(B_CharacterController2 player)
    {
        player.EarnMoney(1);
        yield return new WaitForSeconds(moneyFrequency);
        if (insideArea)
        {
            StartCoroutine(PlatformMoney(player));
        }
    }
    #endregion
}
