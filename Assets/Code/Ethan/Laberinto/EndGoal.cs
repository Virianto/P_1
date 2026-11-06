using UnityEngine;
public class EndGoal : MonoBehaviour
{
    public B_CharacterController player;
    public GameObject EndHud;
    public GameObject NormalHud;


    void Awake()
    {
        player.GetComponent<B_CharacterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("Enemy"))
        {
            EndHud.SetActive(true);
            NormalHud.SetActive(false);

            player.enabled = false;
        }
    }

}
