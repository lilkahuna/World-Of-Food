using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    private float startTime;
    float pollTime = 7.5f; // Seconds between fire spreading
    Vector3 spaceToSpread = new Vector3(5,0,5);
    public GameManager gameManager;
    public PlayerScript player;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time > startTime + pollTime)
        {
            startTime = Time.time;
            CloneFire();
        }
    }

    public void CloneFire()
    {
        Vector3 newFirePos = transform.position + new Vector3(Random.Range(-spaceToSpread.x, spaceToSpread.x), Random.Range(-spaceToSpread.y, spaceToSpread.y), Random.Range(-spaceToSpread.z, spaceToSpread.z));
        GameObject newFire = GameObject.Instantiate(gameObject, newFirePos, Quaternion.identity);
        gameManager.fireNumber += 1;
        //newFire.transform.SetParent(gameObject.transform);
        if (gameManager.fireNumber > 10)
        {
            Destroy(gameObject);
            gameManager.fireNumber = 10;
        }

        Debug.Log(gameManager.fireNumber);
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            player.health -= 1;
        }
            
    }
}
