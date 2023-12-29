using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    Rigidbody rb;

    [Tooltip("how fast do you want the dash")]
    [SerializeField] private float DashSpeed = 20f;
    [Tooltip("how long do you want the dash")]
    [SerializeField] private float DashDuration = 1f;
    private bool DashBool = false;

    [Tooltip("change this how you want")]
    public InputAction DashInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(DashInput.triggered)
        {
            StartCoroutine(SetDash());
        }
    }

    IEnumerator SetDash()
    {
        DashBool = true;
        yield return new WaitForSeconds(DashDuration);
        DashBool = false;
        rb.velocity = Vector3.zero;//reset velocity to avoid drifting
    }

    private void FixedUpdate()
    {
        if(DashBool)
        {
            Dash();
        }
    }

    void Dash()
    {
        rb.AddForce(transform.forward * DashSpeed);
    }

    private void OnEnable()=> DashInput.Enable();

    private void OnDisable()=> DashInput.Disable();
}
