using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public Text healthText;
    public Slider healthSlider;

    public float health;
    public float maxHealth;

    public int coins;
    public int gems;

    public Text coinsText;
    public Text gemsText;
    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);  
        }
        else
        {
            playerStats = this;
        }
    }
    void Start()
    {
        health = maxHealth;
        SetHealthText();
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthText();
    }
    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealthText();
    }
    private void SetHealthText()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }
    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player);
        }
    }
    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    public void AddCurrency (int amount, CurrencyPickup.PickupObject valueType)
    {
        if (valueType == CurrencyPickup.PickupObject.COIN)
        {
            coins += amount;
            coinsText.text = "Gold: " + coins.ToString();
        }
        else if (valueType == CurrencyPickup.PickupObject.GEM)
        {
            gems += amount;
            gemsText.text = "Gems: " + gems.ToString();
        }
    }
}
