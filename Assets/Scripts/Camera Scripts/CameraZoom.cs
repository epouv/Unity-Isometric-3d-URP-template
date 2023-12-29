using UnityEngine.InputSystem;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Tooltip("change this how you want")]
    public InputAction ZoomInput;

    private float zoomAmount;

    Camera cam;

    [Tooltip("the smaller the number, the more we can zoom")]
    public float maxZoom;
    [Tooltip("the greater the number, the more we can un-zoom")]
    public float minZoom;
    public float sensitivity = 1;
    public float speed = 30;
    float targetZoom;

    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        zoomAmount = ZoomInput.ReadValue<float>();

        if(zoomAmount != 0)
        {
            Zoom();
        }
    }

    void Zoom()
    {
        targetZoom -= zoomAmount * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.unscaledDeltaTime);
        cam.orthographicSize = newSize;
    }

    private void OnEnable()=> ZoomInput.Enable();

    private void OnDisable()=> ZoomInput.Disable();
}
