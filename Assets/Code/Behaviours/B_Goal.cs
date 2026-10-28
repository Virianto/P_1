using UnityEngine;

/// <summary>
/// Aquí va el enunciado del propósito de esta clase
/// </summary>
public class B_Goal : MonoBehaviour
{

    #region ATTRIBUTES

    bool agentIsInsideArea = false;

    B_Agents2 npc;
    M_GameManager gameManager;

    #endregion



    #region METHODS

    void OnTriggerEnter(Collider other)
    {
        npc = other.GetComponent<B_Agents2>();


        if (npc !=null)
        {
            gameManager.FinishGame();
        }


    }

    #endregion
}