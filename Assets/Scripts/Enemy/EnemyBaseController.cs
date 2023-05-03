using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private SOEnemySetup _enemySetup;
    [SerializeField] private HealthController healthController;
    private string attackTag = "AttackRange";

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(attackTag))
            Attack();
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _enemySetup.enemySpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }

    private void Attack()
    {
        PlayerController.Instance.HealthController.Damage(_enemySetup.attackDamage);
    }

    private void Die(HealthController healthController)
    {

    }
}
