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
    [SerializeField] private int jemsCollected = 0;

    private Vector3 playerStartingPosition;

    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Stamina { get => stamina; set => stamina = value; }
    public int MaxStamina { get => maxStamina; set => maxStamina = value; }
    public int Mana { get => mana; set => mana = value; }
    public int MaxMana { get => maxMana; set => maxMana = value; }
    public Vector3 PlayerStartingPosition { get => playerStartingPosition; set => playerStartingPosition = value; }
    public int JemsCollected { get => jemsCollected; set => jemsCollected = value; }

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
    private void Start()
    {
        PlayerStartingPosition = transform.position;
    }
}
