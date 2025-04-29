using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{

    [Header("UI Sliders")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private Slider manaSlider;

    void Start()
    {
        SetSlidersValues();
    }

    void Update()
    {
        UpdateSliders();
    }

    private void SetSlidersValues()
    {
        healthSlider.maxValue = Player.Instance.MaxHealth;
        staminaSlider.maxValue = Player.Instance.MaxStamina;
        manaSlider.maxValue = Player.Instance.MaxMana;

        healthSlider.value = Player.Instance.Health;
        staminaSlider.value = Player.Instance.Stamina;
        manaSlider.value = Player.Instance.Mana;
    }
    private void UpdateSliders()
    {
        UpdateHealthSlider();
        UpdateStaminaSlider();
        UpdateManaSlider();
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = Player.Instance.Health;
    }
    private void UpdateStaminaSlider()
    {
        staminaSlider.value = Player.Instance.Stamina;
    }
    private void UpdateManaSlider()
    {
        manaSlider.value = Player.Instance.Mana;
    }
}


