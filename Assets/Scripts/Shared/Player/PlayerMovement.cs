using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed;
    public float m_SprintSpeed;
    public float m_Acceleration;
    public float m_TurnSpeed;
    public float m_CanMove;
    public float m_Deadzone = 0.05f;
    public Rigidbody m_Rib;
    public Camera m_Cam;
    public PlayerManager m_PlayerManager;


    public float maxVelocityChange = 10.0f;
    private float x, y;
    bool isSprinting; 
    private float internalSpeed;
    private Transform camTransform;
    public Vector3 velocity;
    private PlayerInput input;

    private void Awake()
    {
        m_Rib = GetComponent<Rigidbody>();
        x = 0.0f;
        y = 0.0f;
        internalSpeed = m_Speed;
        velocity = transform.forward;

        if(m_Cam == null)
        {
            m_Cam = Camera.main;
        }
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        isSprinting = false;
    }

    private void FixedUpdate()
    {
        x = m_PlayerManager.Horizontal;
        y = m_PlayerManager.Vertical;
        isSprinting = m_PlayerManager.Sprinting;

        // isSprinting = input.GetA();
        if(m_Cam != null)
        {
            if(camTransform == null)
            {
                camTransform = m_Cam.transform;
            }

            // handle sprinting
            if(isSprinting) { internalSpeed = m_SprintSpeed; }
            else { internalSpeed = m_Speed; }

            if (Mathf.Abs(x) > m_Deadzone || Mathf.Abs(y) > m_Deadzone)
            {
                // mvoement is relative to CAMERA direction
                Vector3 forward = camTransform.forward;
                Vector3 right = camTransform.right;


                forward.Normalize();
                right.Normalize();

                Vector2 normalizedInput = new Vector2(x, y);
                normalizedInput.Normalize();

                // Calculate how fast we should be moving
                Vector3 targetVelocity = (right * normalizedInput.x) + (forward * normalizedInput.y);
                targetVelocity.Normalize();
                Vector3 debugDirection = targetVelocity;
                targetVelocity *= internalSpeed;

                // Apply a force that attempts to reach our target velocity
                velocity = m_Rib.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                m_Rib.AddForce(velocityChange, ForceMode.VelocityChange);

                this.transform.rotation = Quaternion.LookRotation(velocity);
            }
            else
            {
                Vector3 targetVelocity = Vector3.zero;
                velocity = m_Rib.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                m_Rib.AddForce(velocityChange, ForceMode.VelocityChange);
            }

        }

        

    }
}
