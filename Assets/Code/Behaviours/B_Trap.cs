using UnityEngine;

public class B_Trap : MonoBehaviour
{

    #region ATTRIBUTES
    //Daño que hace esta trampa
    [SerializeField]
    [Range(0, 10)]
    int trapDamage = 1;
    //Frecuencia conqe hace daño esta trampa
    [SerializeField]
    [Range(0.5f, 3)]
    float trapFrequencyDamage = 1;
    bool playerIsInsideArea = false;

    #endregion

    #region METHODS
    private void OnTriggerEnter(Collider other)
    {
        //detectar cuando ha entrado el jugador en su area de efecto 
        playerIsInsideArea = true;
        Debug.Log("jugador entro");
    }

    private void OnTriggerExit(Collider other)
    {
        //detectar cuando ha salido el jugador de su area de efecto 
        playerIsInsideArea = false;
        Debug.Log("jugador salio");
    }

    //declarar u nmetodo      

    #endregion
}
