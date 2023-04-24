using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public float floatingHeight = 2.0f;
    public float floatingSpeed = 2.0f;
    public float rotationSpeed = 80f;

    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        Vector3 newPos = transform.position;
        newPos.y = startY + offset;

        transform.position = newPos;
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.collectibleAcquired = true;
        }
    }
}
