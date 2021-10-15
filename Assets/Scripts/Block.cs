using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    LevelManager levelManager;
    GameStatus gameStatus;

    const float SECONDS_TO_DESTROY_SPARKLE = 1f;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameStatus = FindObjectOfType<GameStatus>();
        levelManager.AddBlockCount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        levelManager.RemoveDestroyedBlock();
        gameStatus.AddScore();
        TriggerParticlesVFX();
        Destroy(gameObject, 0);
    }

    private void TriggerParticlesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, SECONDS_TO_DESTROY_SPARKLE);
    }
}
