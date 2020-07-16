using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = targetToFollow.position;
        target = new Vector3(target.x + xOffset, target.y + yOffset, target.z);
        Vector3 camMove = Vector3.Lerp(transform.position, target, 0.1f);
        transform.position = new Vector3(camMove.x, camMove.y, 0f);
    }
}
