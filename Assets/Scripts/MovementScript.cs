using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovementScript : MonoBehaviour
{
    [Header("Layer")]
    LayerMask layer;

    [Header("Stats")]
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float rotationSpeedx, rotationSpeedy;
    [SerializeField]
    Rigidbody rigidbody;
    Vector2 InputVector;
    [SerializeField]
    bool isGrounded = false;

    [SerializeField]
    Transform cameraFollowTransform;
    public void OnMove(InputValue value)
    {
        InputVector = value.Get<Vector2>();
        InputVector = InputVector.normalized;

        Debug.Log(InputVector.ToString());
    }

    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            Vector3 jumpDirection = new Vector3(0, 1, 0) * jumpForce * transform.localScale.y;
            rigidbody.AddForce(jumpDirection, ForceMode.Impulse);
        }
    }

    public void OnLook(InputValue value)
    {
        Vector2 lookDelta = value.Get<Vector2>();

        Quaternion temp = transform.rotation;
        temp *= Quaternion.Euler(0, lookDelta.x /** rotationSpeedx*/, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, temp, Time.deltaTime);

        temp = transform.rotation;
        temp *= Quaternion.Euler(-lookDelta.y, 0, 0);

        cameraFollowTransform.rotation = Quaternion.Slerp(cameraFollowTransform.rotation, temp, Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //InputVector = transform.forward * InputVector.y + transform.right * InputVector.x;
        //Vector3 inputVector = new Vector3(transform.forward * InputVector.x, 0, InputVector.y);
        Vector3 inputVector = transform.forward * InputVector.y + transform.right * InputVector.x;
        Vector3 movementDirection = inputVector * (speed * Time.deltaTime);
        transform.position += movementDirection;

        isGrounded = IsGrounded();
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, new Vector3(0, -1, 0), transform.localScale.y + 0.1f);
    } 
}
