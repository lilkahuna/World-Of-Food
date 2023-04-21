using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;

public class Float : MonoBehaviour
{
    public float height = 1.0f;
    public float speed = 1.0f;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * height;
        Vector3 newPos = transform.position;
        newPos.y = startY + offset;
        GetComponent<Rigidbody>().MovePosition(newPos);
    }
}
