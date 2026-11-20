using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    [SerializeField] private bool testDamage = false;
    [SerializeField] private bool testHeal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (testDamage)
        {
            TakeDamage(10);
            testDamage = false;
        }
        if (testHeal)
        {
            Heal(10);
            testHeal = false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
