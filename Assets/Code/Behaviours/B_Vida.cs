using UnityEngine;

public class B_Vida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 50;

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Vida: " + currentHealth);
    }
}

