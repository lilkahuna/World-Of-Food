using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2.5f, 0);

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}