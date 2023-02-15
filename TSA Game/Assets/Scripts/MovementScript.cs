using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour

{
    int speed = 5;
    RigidBody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("KeyHorizontal");
        float verticalMove = Input.GetAxis("KeyVertical");

        Vector2 movement = new Vector2(horizontalMove, verticalMove);

    }
}