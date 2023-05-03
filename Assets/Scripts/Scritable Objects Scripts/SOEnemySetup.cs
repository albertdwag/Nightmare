using UnityEngine;

[CreateAssetMenu]
public class SOEnemySetup : ScriptableObject
{
    [Header("Life Settings")]
    public float life = 15f;

    [Header("Movement Settings")]
    public float enemySpeed = 2f;
    public float attackDamage = 2f;
}
