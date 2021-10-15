using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int totalBlocks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddBlockCount()
    {
        totalBlocks++;
    }

    public void RemoveDestroyedBlock()
    {
        totalBlocks--;

        if(AllBlocksAreDestroyed())
        {
            sceneLoader.LoadNextScene();
        }
    }

    private bool AllBlocksAreDestroyed()
    {
        return totalBlocks == 0;
    }
}
