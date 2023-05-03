using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : Singleton<PlayerController>
{
    private CharacterController controller;
    private InputManager inputManager;
    [SerializeField] private SOPlayerSetup _playerSetup;
    [SerializeField] private HealthController healthController;
    private Vector3 playerVelocity;
    private readonly float gravityValue = -9.81f;
    private Transform cameraTransform;

    protected override void Awake()
    {
        base.Awake();
        healthController.OnDeath += Die;
        healthController.OnDamage += Damage;
        healthController.StartLife = _playerSetup.life;
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        healthController = GetComponent<HealthController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;

        controller.Move(_playerSetup.playerSpeed * Time.deltaTime * move);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Damage(HealthController healthController)
    {

    }

    private void Die(HealthController healthController)
    {
        
    }
}
