using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;
    Vector3 velocity;
    [SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f;

    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public Transform groundCheckerOrigin;
    public LayerMask groundLayer;
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
        Vector2 playerInput;
		playerInput.x = Input.GetAxis("Horizontal");
		playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        
        Vector3 desiredVelocity = 
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
			Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
		velocity.z =
			Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        
        Vector3 displacement = velocity * Time.deltaTime;   
		transform.localPosition += displacement;


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
    }

    private void Jump()
    {
        
    }
}
