using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int maxEnemies = 10;
    public float spawnRate = 1.0f;
    public float enemySpacing = 2.0f;

    private int currentEnemies = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                GameObject enemy = EnemyPoolManager.Instance.GetEnemyFromPool();
                if (enemy != null)
                {
                    enemy.transform.position = transform.position;
                    enemy.SetActive(true);
                    var controller = enemy.GetComponent<EnemyBaseController>();
                    controller.enemyGenerator = this;
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
