using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphereNew : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    Vector3 velocity, desiredVelocity;
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    bool desiredJump;
    [SerializeField, Range(0f, 10f)]
    float jumpHeight = 2f;
    bool onGround;
    [SerializeField, Range(0, 5)]
	int maxAirJumps = 0;
    int jumpPhase;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            Vector2 playerInput;
            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.y = Input.GetAxis("Vertical");
            playerInput = Vector2.ClampMagnitude(playerInput, 1f);
            desiredVelocity =
                new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

            desiredJump |= Input.GetButtonDown("Jump");
        }

        void FixedUpdate()
        {
            if (desiredJump)
            {
                desiredJump = false;
                Jump();
            }
            UpdateState();

            float maxSpeedChange = maxAcceleration * Time.deltaTime;
            velocity.x =
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
            velocity.z =
                Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
            body.velocity = velocity;
            onGround = false;
            
        }
        
        void UpdateState () 
        {
		    velocity = body.velocity;
		    if (onGround) 
            {
			    jumpPhase = 0;
		    }
	    }
    }

    void Jump()
    {
        if (onGround || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            if (velocity.y > 0f) 
            {
				jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
			}
            velocity.y += jumpSpeed;
        }
    }
    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }

    void EvaluateCollision (Collision collision) 
    {
        for (int i = 0; i < collision.contactCount; i++) 
        {
			Vector3 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
		}
    }
}
