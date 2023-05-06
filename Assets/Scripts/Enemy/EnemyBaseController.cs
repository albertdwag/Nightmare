using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;

    [SerializeField] private SOEnemySetup _enemySetup;
    [SerializeField] private HealthController healthController;
    [SerializeField] private UnityEngine.AI.NavMeshAgent enemyAI;
    private PlayerController _target;
    private bool canMove = false;
    private readonly string attackTag = "AttackRange";

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        enemyAI = GetComponent<UnityEngine.AI.NavMeshAgent>();
        healthController.OnDeath += Die;
        healthController.StartLife = _enemySetup.life;
    }

    private void Start()
    {
        _target = PlayerController.Instance;
        enemyAI.speed = _enemySetup.enemySpeed;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(attackTag))
        {
            canMove = false;
            Attack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(attackTag))
            canMove = true;
    }

    private void HandleMovement()
    {
        if (canMove)
            enemyAI.SetDestination(_target.transform.position);
        else
            enemyAI.SetDestination(Vector3.zero);
    }

    private void Attack()
    {
        PlayerController.Instance.HealthController.Damage(_enemySetup.attackDamage);
    }

    private void Die(HealthController healthController)
    {
        gameObject.SetActive(false);
        enemyGenerator.OnEnemyDestroyed();
        ResetLife();
    }

    private void ResetLife()
    {
        healthController.CurrentLife = _enemySetup.life;
    }
}
