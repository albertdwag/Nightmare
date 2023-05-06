using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int maxEnemies = 3;
    public float spawnRate = 1.0f;
    public float enemySpacing = 2.0f;

    private static int currentEnemies = 0;
    private string spawnableTag = "SpawnRange";
    private bool canSpawnEnemies = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(spawnableTag))
        {
            canSpawnEnemies = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(spawnableTag))
        {
            canSpawnEnemies = false;
            StopCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (canSpawnEnemies)
        {
            if (currentEnemies <= maxEnemies)
            {
                GameObject enemy = EnemyPoolManager.Instance.GetEnemyFromPool();
                if (enemy != null)
                {
                    enemy.transform.position = transform.position;
                    enemy.SetActive(true);
                    var controller = enemy.GetComponent<EnemyBaseController>();
                    controller.enemyGenerator = this;
                    currentEnemies++;
                }
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void OnEnemyDestroyed()
    {
        currentEnemies--;
    }
}
