using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 playerVelocity;
    private readonly float playerSpeed = 2.0f;
    private readonly float gravityValue = -9.81f;
    private Transform cameraTransform;


    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;

        controller.Move(move * Time.deltaTime * playerSpeed);
                

        //if (move != Vector3.zero)
        //    gameObject.transform.forward = move;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
