using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float waitToPlayerRespawn = 2f;
    [SerializeField] GameObject playerPrefab;

    
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

    public void RespawnPlayer()
    {
        if (CheckpointController.Instance.CurrentCheckpoint != null)
        {
            StartCoroutine(RespawnPlayerCoroutine(CheckpointController.Instance.CurrentCheckpoint.transform.position));
        }
        else
        {
            StartCoroutine(RespawnPlayerCoroutine(Player.Instance.PlayerStartingPosition));
        }
    }

    private IEnumerator RespawnPlayerCoroutine(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(waitToPlayerRespawn);
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}
