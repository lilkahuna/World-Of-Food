using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3 (0, 0, -1);

    void LateUpdate()
    {
        transform.position  = player.transform.position + offset;
    }
}
