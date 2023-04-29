using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Private variables that can be tweaked in the inspector
    [SerializeField] private float moveSpeed; // player movement speed
    [SerializeField] private float rotationSpeed = 180f; // player rotation speed
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cameraTransform; // the camera's transform component
    [SerializeField] private float cameraDistance = 3f; // distance from camera to player
    [SerializeField] private float cameraHeight = 2.5f; // height of camera above player
    [SerializeField] private Vector3 playerLookAt = Vector3.forward;

    // Private variables that are cached for performance
    private Transform playerTransform; // cached transform component
    private Animator anim;
    private bool isWalking = false;
    private Vector3 moveDirection; // movement direction vector

    private void Awake()
    {
        // Cache the transform and animator components
        playerTransform = transform;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // Lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!gameManager.playerCanMove) return;

        // Get movement input
        float moveForward = Input.GetAxis("KeyVertical");
        float moveSide = Input.GetAxis("KeyHorizontal");

        // Calculate movement direction vector
        moveDirection = playerTransform.forward * moveForward + playerTransform.right * moveSide;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // Move the player
        playerTransform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Get camera rotation input
        float rotatePlayerX = Input.GetAxis("Mouse X");

        // Rotate the player based on input
        playerTransform.Rotate(Vector3.up, rotatePlayerX * rotationSpeed * Time.deltaTime, Space.World);

        // Update walking animation
        bool isMoving = moveForward != 0 || moveSide != 0;
        if (isMoving != isWalking)
        {
            isWalking = isMoving;
            anim.SetBool("IsWalking", isMoving);
        }

        // Update camera position and rotation
        if (cameraTransform != null)
        {
            // Calculate camera position relative to player
            Vector3 cameraOffset = -playerTransform.forward * cameraDistance + Vector3.up * cameraHeight;

            // Set camera position and rotation
            cameraTransform.position = playerTransform.position + cameraOffset;
            cameraTransform.LookAt(playerTransform.position + playerTransform.TransformDirection(playerLookAt));
        }
    }
}
