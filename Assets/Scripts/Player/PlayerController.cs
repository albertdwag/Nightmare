using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    [SerializeField] private HealthController healthController;
    private Vector3 playerVelocity;
    private readonly float playerSpeed = 2.0f;
    private readonly float gravityValue = -9.81f;
    private Transform cameraTransform;

    private void Awake()
    {
        healthController.OnDeath += Die;
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

        controller.Move(playerSpeed * Time.deltaTime * move);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Die(HealthController healthController)
    {
        
    }
}
