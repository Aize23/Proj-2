using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Jumping")]
    [Tooltip("The button we want to press to jump")]
    public KeyCode jumpKey = KeyCode.Space;
    [Tooltip("Style of jump. Instant is a jump on key press. Charged requires holding jump to build up a charge, then performs the jump on key release")]
    public JumpStyle jumpStyle = JumpStyle.Instant;
    [Tooltip("If true, a jump will happen on the next FixedUpdate")]
    [SerializeField] bool performJump = false;
    [Tooltip("How many seconds the jump key has been held for")]
    [SerializeField] float jumpHeldTime = 0;
    [Tooltip("The longest the jump key can be held for")]
    [SerializeField] float jumpHeldTimeMax = 1;
    [Tooltip("Strength of a jump. It is a vertical velocity in m/s")]
    [SerializeField] float jumpStrength = 6;
    [Tooltip("The minimum jump velocity. A short jump hold will always use at least this")]
    [SerializeField] float jumpStrengthMin = 2;
    [Tooltip("The total charge used for jumping. In instant jumps, this is jumpStrength. In charged jumps, it is jumpHeld/jumpHeldMax*jumpStrength")]
    [SerializeField] float jumpCharge = 0;

    [Header("Walking")]
    [Tooltip("")]
    public float walkSpeed = 4.0f;

    [Header("Sensors")]
    [Tooltip("Radius of the ground sensor sphere that detects the ground under the player")]
    public float groundSensorRadius = 0.2f; // Test
    [Tooltip("Vertical offset of the centre of the ground sensor sphere")]
    public float groundSensorOffset = -0.9f; // assuming you are using default capsule
    [Tooltip("If true, the player is standing on something")]
    public bool onGround = false;

    [Header("Rotation")]
    [Tooltip("Rotation around the Y Axis (look around)")]
    [SerializeField] float yaw = 0;
    [Tooltip("Rotation around the X Axis (look up and down")]
    [SerializeField] float pitch = 0;
    [Tooltip("Yaw speed")]
    [SerializeField] float yawSpeed = 1;
    [Tooltip("Pitch speed")]
    [SerializeField] float pitchSpeed = 1;
    [Tooltip("Camera attached to the player, used for pitch")]
    public Transform childCamera;


    [Tooltip("Minimum Pitch")]
    [SerializeField] float pitchMinimum = -80.0f;
    [Tooltip("Maximum Pitch")]
    [SerializeField] float pitchMaximum = 80.0f;



    [Header("Debug")]
    [Tooltip("Current desired velocity based on velocity")]
    [SerializeField] Vector3 desiredVelocity = Vector3.zero;


    public enum JumpStyle
    {
        Instant,    // Jump performed on key press, always same strength
        Charged     // Build up a charge by holding the jump key
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {



        
        transform.rotation = Quaternion.Euler(new Vector3(0, yaw, 0));
        if(childCamera != null)
        {
            childCamera.transform.localRotation = Quaternion.Euler(new Vector3(pitch, 0, 0));
        }
        desiredVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * walkSpeed;
    }

    public void Jump(float strength)
    {
        performJump = true;
        jumpCharge = strength;
    }

    void FixedUpdate()
    {
        onGround = false;
        Collider[] hits = Physics.OverlapSphere(transform.position + new Vector3(0, groundSensorOffset, 0), groundSensorRadius);
        foreach (Collider c in hits)
        {
            if(c.gameObject != gameObject)
            {
                onGround = true;
                break;
            }
        }
        
        Vector3 vel = transform.forward * desiredVelocity.z + transform.right * desiredVelocity.x;
        vel.y = rb.velocity.y;

        if(performJump)
        {
            vel.y = jumpCharge;
            performJump = false;
        }

        rb.velocity = vel;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(0,groundSensorOffset,0), groundSensorRadius);
    }
}
