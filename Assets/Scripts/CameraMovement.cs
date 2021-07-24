using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, moveSpeed * Time.deltaTime);
        }
    }
}
