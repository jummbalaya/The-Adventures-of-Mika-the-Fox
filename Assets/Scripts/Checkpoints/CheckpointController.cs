using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController Instance { get; private set; }
    private Checkpoint[] checkpoints;
    private Checkpoint currentCheckpoint;

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
        if (currentCheckpoint != null)
        {
            currentCheckpoint.DeactivateCheckpoint();
        }
        currentCheckpoint = checkpoint;
    }
    
    public void RespawnPlayer(Transform playerTransform)
    {
        if (currentCheckpoint != null)
        {
            playerTransform.position = currentCheckpoint.transform.position;
        }
    }

    public void ResetCheckpoints()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.DeactivateCheckpoint();
        }
    }
}
