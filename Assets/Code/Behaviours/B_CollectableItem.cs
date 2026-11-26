using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito 
/// </summary>
public class B_CollectableItem : MonoBehaviour
{

    #region ATTRIBUTES



    #endregion


    #region METHODS


    void OnTriggerEnter(Collider other)
    {
      B_CoinCharacter player = other.GetComponent<B_CoinCharacter>();
        if(player != null)
        {
            //Lanzo un evento de "ObjetoRecolectado"
            //Aquí podría ir la invocación al método que lance partículas, sonido, etc.
            //a través del manager
        }
    }
    #endregion
}
