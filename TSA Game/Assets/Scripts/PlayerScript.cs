using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed = 180f;

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraDistance = 3f;
    [SerializeField] private float cameraHeight = 2.5f;
    [SerializeField] private Vector3 playerLookAt = Vector3.forward;

    [Header("References")]
    [SerializeField] private GameManager gameManager;

    private Transform playerTransform;
    private Animator anim;
    private bool isWalking = false;
    private Vector3 moveDirection;

    private void Awake()
    {
        playerTransform = transform;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
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
        bool isMoving = moveForward != 0f || moveSide != 0f;
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
