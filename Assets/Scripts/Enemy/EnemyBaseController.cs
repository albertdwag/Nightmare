using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private SOEnemySetup _enemySetup;
    [SerializeField] private HealthController healthController;

    private void Awake()
    {
        healthController.OnDeath += Die;
        healthController = GetComponent<HealthController>();
        healthController.StartLife = _enemySetup.life;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _enemySetup.enemySpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }

    private void Die(HealthController healthController)
    {

    }
}
