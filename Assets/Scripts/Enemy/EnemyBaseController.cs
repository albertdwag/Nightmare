using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;

    [SerializeField] private SOEnemySetup _enemySetup;
    [SerializeField] private HealthController healthController;
    private PlayerController _target;
    private bool canMove = false;
    private readonly string attackTag = "AttackRange";
    private readonly string followTag = "FollowRange";

    private void Awake()
    {
        healthController.OnDeath += Die;
        healthController = GetComponent<HealthController>();
        healthController.StartLife = _enemySetup.life;
    }

    private void Start()
    {
        _target = PlayerController.Instance;
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
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _enemySetup.enemySpeed * Time.deltaTime);
            transform.LookAt(_target.transform);
        }
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
