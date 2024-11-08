using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public float health = 3;
    public Transform groundCheckerOrigin;
    public LayerMask groundLayer;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rBody;
    private bool isGrounded = false;
    private bool hasHitJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            hasHitJump = true;
        }
    }

    private void FixedUpdate()
    {
        Jump();
            isGrounded = Physics.CheckSphere(groundCheckerOrigin.position, distanceToGround, groundLayer);

            if(isGrounded == true && hasHitJump == true)
            {
                rBody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
                hasHitJump = false;
            }

        Movement();
            Vector3 rotation = Vector3.up * horizontalInput;

            Quaternion angleRototation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
            rBody.MovePosition(this.transform.position + transform.forward * verticalInput * Time.fixedDeltaTime);
            rBody.MoveRotation(rBody.rotation * angleRototation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Pickup")
        {
            Destroy(other.gameObject);
            health -= 1;
        }
    }

    private void Movement()
    {
        
    }

    private void Jump()
    {
        
    }
}
