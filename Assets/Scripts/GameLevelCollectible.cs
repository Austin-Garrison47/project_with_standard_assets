
using UnityEngine;

public class GameLevelCollectible : MonoBehaviour
{
    public GameLevelManager gameLevelManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameLevelManager.CollectObject();
            Destroy(gameObject);
        }
    }
}
