using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("what transform does the camera follows")]
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
