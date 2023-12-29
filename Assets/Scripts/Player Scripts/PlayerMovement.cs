using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Move")]
    [Tooltip("how fast does the player move")]
    [SerializeField] private float speed = 10f;
    [Tooltip("how fast does the player rotate")]
    [SerializeField] private float rotationSpeed = 180f;
    [Tooltip("change this how you want")]
    public InputAction MoveInput;

    Vector2 InputVector;
    Vector3 MoveVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputVector = MoveInput.ReadValue<Vector2>();
        MoveVector = new(InputVector.x, 0f, InputVector.y);
    }

    private void FixedUpdate()
    {
        Look();
        Move();
    }

    void Look()
    {
        if(InputVector != Vector2.zero)
        {
            var rot = Quaternion.LookRotation(MoveVector.ToIso(), Vector3.up);//ToIso() is located in Helpers.cs, it rotates the direction vector to match the isometric view
            var targetRot = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRot, Time.fixedDeltaTime * 5));
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + speed * Time.fixedDeltaTime * (transform.forward * MoveVector.magnitude));
    }

    private void OnEnable()=> MoveInput.Enable();

    private void OnDisable()=> MoveInput.Disable();
}
