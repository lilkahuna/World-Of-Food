using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool collectibleAcquired = false;
    [SerializeField] Text indicatorText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibleAcquired)
        {
            StartCoroutine(CollectibleCollected);
        }

        public IEnumerator CollectibleCollected()
        {
            indicatorText.Text = "Level Collectible Acquired";
            yield new WaitForSeconds(5);
            indicatorText.Text = "Head towards the Restaurant";
        }
    }
}