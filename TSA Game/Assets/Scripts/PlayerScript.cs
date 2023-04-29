using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour

{
    public float speed; // player speed
    public float rotationSpeed = 180f; // camera rotation speed

    public GameManager gameManager;

    private Transform playerTransform; // cached transform component
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerTransform = transform; // cache the transform component
    }

    
    // Update is called once per frame
    void Update()
    {
        if (anim)
        {
            anim.SetBool("IsWalking", true);
            Debug.Log("Animator Present");
        }
        
        if (gameManager.playerCanMove)
        {
            // get the input axis values for forward and backward movement
            float moveForward = Input.GetAxis("KeyVertical");

            // create a movement vector based on the input and speed
            Vector3 movement = playerTransform.forward * moveForward * speed * Time.deltaTime;

            // add the movement vector to the player's position
            playerTransform.position += movement;

            // get the input axis value for camera rotation
            float rotateCamera = Input.GetAxis("KeyHorizontal");

            // create a rotation vector based on the input and rotation speed
            Vector3 rotation = new Vector3(0f, rotateCamera, 0f) * rotationSpeed * Time.deltaTime;

            // rotate the camera based on the input
            playerTransform.localRotation *= Quaternion.Euler(rotation);
        }

    }

    public void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
            }
    }
}