using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Sprite cpOn;
    [SerializeField] private Sprite cpOff;
    
    private SpriteRenderer spriteRenderer;
    private bool isActive;

    public bool IsActive { get => isActive; set => isActive = value; }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateCheckpoint();
            CheckpointController.Instance.SetCurrentCheckpoint(this);
        }
    }

    private void ActivateCheckpoint()
    {
        spriteRenderer.sprite = cpOn;
        IsActive = true;
    }

    public void DeactivateCheckpoint()
    {
        spriteRenderer.sprite = cpOff;
        IsActive = false;
    }
}
