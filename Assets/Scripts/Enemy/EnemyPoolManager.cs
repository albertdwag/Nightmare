using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : Singleton<EnemyPoolManager>
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private List<GameObject> enemyPool;

    private void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemy.transform.parent = transform;
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
                return enemyPool[i];
        }
        return null;
    }
}
