using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : Singleton<PlayerController>
{
    public HealthController HealthController
    {
        get { return _healthController; }
    }

    private CharacterController controller;
    private InputManager inputManager;
    [SerializeField] private SOPlayerSetup _playerSetup;
    [SerializeField] private HealthController _healthController;
    private Vector3 playerVelocity;
    private readonly float gravityValue = -9.81f;
    private Transform cameraTransform;

    protected override void Awake()
    {
        base.Awake();
        _healthController.OnDeath += Die;
        _healthController.OnDamage += Damage;
        _healthController.StartLife = _playerSetup.life;
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        _healthController = GetComponent<HealthController>();
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
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

    public void Damage(HealthController healthController)
    {

    }

    private void Die(HealthController healthController)
    {
        
    }
}
