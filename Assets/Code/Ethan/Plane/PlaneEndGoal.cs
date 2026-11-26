using UnityEngine;

public class SimpleEndGoal : MonoBehaviour
{
    public EthanPlaneController player;
    public GameObject EndHud;
    public GameObject NormalHud;


    void Awake()
    {
        player.GetComponent<EthanPlaneController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            EndHud.SetActive(true);
            NormalHud.SetActive(false);

            player.enabled = false;
        }
    }
}
