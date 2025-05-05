using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController Instance { get; private set; }

    private Checkpoint[] checkpoints;
    private Checkpoint currentCheckpoint;
    public Checkpoint CurrentCheckpoint { get => currentCheckpoint; set => currentCheckpoint = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        checkpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
    }
    public void SetCurrentCheckpoint(Checkpoint checkpoint)
    {
        if (CurrentCheckpoint != null)
        {
            CurrentCheckpoint.DeactivateCheckpoint();
        }
        CurrentCheckpoint = checkpoint;
    }
    
    public void ResetCheckpoints()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.DeactivateCheckpoint();
        }
    }
}
