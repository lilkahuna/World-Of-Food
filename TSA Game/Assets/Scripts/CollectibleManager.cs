using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public float floatingHeight = 1.0f;
    public float floatingSpeed = 1.0f;

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
    }

    public void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.collectibleAcquired = true;
        }
    }
}
