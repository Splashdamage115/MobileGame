using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject healthBar;
    public Transform healthBarPosition;
    private Slider healthBarSlider;

    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar = Instantiate(healthBar, healthBarPosition);
        healthBarSlider = healthBar.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmt)
    {
        currentHealth -= damageAmt;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            updateSlider();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            updateSlider();
        }

    }

    void updateSlider()
    {
        healthBarSlider.value = math.clamp((float)currentHealth / (float)maxHealth, 0.0f, 1.0f);
    }
}
