using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        x = input.GetLSX();
        y = input.GetLSY();

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

                forward.y = 0.0f;
                right.y = 0.0f;

                Vector2 normalizedInput = new Vector2(x, y);
                normalizedInput.Normalize();

                // Calculate how fast we should be moving
                Vector3 targetVelocity = (forward * normalizedInput.y) + (right * normalizedInput.x);
                Vector3 debugDirection = targetVelocity;
                targetVelocity = camTransform.TransformDirection(targetVelocity);
                targetVelocity *= internalSpeed;

                // Apply a force that attempts to reach our target velocity
                velocity = m_Rib.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                m_Rib.AddForce(velocityChange, ForceMode.VelocityChange);
            }

        }

        this.transform.rotation = Quaternion.LookRotation(velocity);

    }
}
