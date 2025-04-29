using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private int maxDamage = 20;
    [SerializeField] private int stamina = 100;
    [SerializeField] private int maxStamina = 100;
    [SerializeField] private int mana = 100;
    [SerializeField] private int maxMana = 100;
    [SerializeField] private int level = 1;
    [SerializeField] private int experience = 0;

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Stamina { get => stamina; set => stamina = value; }
    public int MaxStamina { get => maxStamina; set => maxStamina = value; }
    public int Mana { get => mana; set => mana = value; }
    public int MaxMana { get => maxMana; set => maxMana = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
