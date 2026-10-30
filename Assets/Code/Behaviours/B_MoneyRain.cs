using UnityEngine;

public class B_MoneyRain : MonoBehaviour
{
    #region ATTRIBUTES

    bool playerIsInsideArea = false;

    [SerializeField]
    [Range(0, 10)]
    int addMoney = 1;


    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;

      
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
    }




    #endregion 

}
