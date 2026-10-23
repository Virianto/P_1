using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class B_TrapDelete : MonoBehaviour
{
    #region ATTRIBUTES

    //detectar cuando ha entrado el player
    //detectar cuando ha salido el player
    //habilitar el boton para desactivar trampas
    //deshabilitar el boton
    //desvincular la trampa que controla esta plataforma con el OnClick del boton

    public M_GameManager gameManager; //ref a mi gestor de escena

    public GameObject trapGameObject;

    [SerializeField]
    Button trapButton;

    [SerializeField]
    GameObject trap1;

    

    bool playerIsInsideArea = false;

    #endregion

    #region METHODS

    private void OnTriggerEnter(Collider other)
    {
        playerIsInsideArea = true;
        gameManager.EnableTrapButton(trapGameObject);
        trapButton.onClick.AddListener(DeleteTrap);
    }

    public void DeleteTrap()
    {
        B_Trap trap = GetComponent<B_Trap>();

        GetComponent<Collider>().enabled = false;

        trap1.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInsideArea = false;
        gameManager.DisableTrapButton();
    }

    #endregion
}
