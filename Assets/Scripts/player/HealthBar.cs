using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HealthBarImage;
    public float currentHealthy;
    public float MaxHealth = 100f;
    PlayerInventory Player;

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        Player = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        currentHealthy = (float)Player.currentHealth;
        HealthBarImage.fillAmount = currentHealthy / MaxHealth;
    }
}
