using UnityEngine;
public class UDied : MonoBehaviour
{
    B_CharacterController player;
    public GameObject EndHud;
    public GameObject NormalHud;


    public void Awake()
    {
        player = GetComponent<B_CharacterController>();
    }
    public void Update()
    {
        if (player.lifePointsLeft <= 0)
        {
            EndHud.SetActive(true);
            NormalHud.SetActive(false);

            player.enabled = false;
        }
    }
}
