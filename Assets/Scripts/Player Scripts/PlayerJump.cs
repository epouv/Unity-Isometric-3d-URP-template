using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;

    [Tooltip("how high can the player jump")]
    [SerializeField] float JumpForce = 4f;
    [Tooltip("should be more than half the size of your character")]
    [SerializeField] float GroundCheckDistance = 1.5f;
    [SerializeField] LayerMask groundLayer;
    [Tooltip("can the player jump again after having jumped once")]
    [SerializeField] bool canDoubleJump;
 
    [Tooltip("change this how you want")]
    public InputAction JumpInput;

    bool firstJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(JumpInput.triggered)
        {
            if(GroundCheck())
            {
                Jump();
                firstJump = true;
            }else if(firstJump && canDoubleJump){
                Jump();
                firstJump = false;
            }
        }
    }

    bool GroundCheck()
    {
        return transform.GroundDetection(GroundCheckDistance, groundLayer);
        //GroundDetection() is located in Helpers.cs
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    private void OnEnable()=> JumpInput.Enable();

    private void OnDisable()=> JumpInput.Disable();
}
