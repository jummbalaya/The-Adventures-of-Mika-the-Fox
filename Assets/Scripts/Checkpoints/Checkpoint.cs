using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Sprite cpOn;
    [SerializeField] private Sprite cpOff;
    
    private SpriteRenderer spriteRenderer;
    private bool isActive = false;

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
        isActive = true;
    }

    public void DeactivateCheckpoint()
    {
        spriteRenderer.sprite = cpOff;
        isActive = false;
    }
}
