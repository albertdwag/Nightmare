using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public PlayerController target;
    [SerializeField] private SOEnemySetup _enemySetup;
    [SerializeField] private HealthController healthController;
    private readonly string attackTag = "AttackRange";
    private readonly string followTag = "FollowRange";
    private bool canMove = false;

    private void Awake()
    {
        healthController.OnDeath += Die;
        healthController = GetComponent<HealthController>();
        healthController.StartLife = _enemySetup.life;
    }

    private void Start()
    {
        target = PlayerController.Instance;
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

        if (other.transform.CompareTag(followTag))
            canMove = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(attackTag))
            canMove = true;

        if (other.transform.CompareTag(followTag))
            canMove = false;
    }

    private void HandleMovement()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _enemySetup.enemySpeed * Time.deltaTime);
            transform.LookAt(target.transform);
        }
    }

    private void Attack()
    {
        PlayerController.Instance.HealthController.Damage(_enemySetup.attackDamage);
    }

    private void Die(HealthController healthController)
    {
        Destroy(gameObject);
    }
}
