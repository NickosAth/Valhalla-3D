using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    private bool isClimbing;
    private float climbSpeed = 5f;
    private float gravity;
    private Vector3 climbVelocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isClimbing)
        {
            float climb = Input.GetAxis("Vertical");
            climbVelocity.y = climb * climbSpeed;
            gravity -= Time.deltaTime * 9.8f;
            climbVelocity.y += gravity;
            controller.Move(climbVelocity * Time.deltaTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ladder"))
            {
                isClimbing = true;
                gravity = 0f;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ladder"))
            {
                isClimbing = false;
                gravity = -1f;
            }
        }
    }
}
