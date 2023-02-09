using UnityEngine;

public class dodge : MonoBehaviour
{
    public float dodgeRollSpeed = 2.0f;
    public float dodgeRollDistance = 5f;
    public float dodgeRollDuration = 0.5f;
    private bool isDodging = false;
    private float dodgeTimer = 0f;
    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isDodging)
        {
            // Create a ray that starts at the player's position and points in the forward direction
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Check if the ray hits any colliders within the dodgeRollDistance
            if (Physics.Raycast(ray, out hit, dodgeRollDistance))
            {
                // If a collider is hit, do not perform the dodge
                return;
            }
            else
            {
                // If no colliders are hit, proceed with the dodge animation
                isDodging = true;
                dodgeTimer = 0f;
                animator.SetTrigger("dodge");
                startingPosition = transform.position;
                targetPosition = transform.position + transform.forward * dodgeRollDistance;
            }
        }

        if (isDodging)
        {
            // Check the animator's state info to determine if the dodge animation is still playing
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Dodge") && stateInfo.normalizedTime < 1)
            {
                // If the dodge animation is still playing, do not move the character yet
                return;
            }

            // If the dodge animation has finished playing, move the character to the target position
            dodgeTimer += Time.deltaTime;
            float t = dodgeTimer / dodgeRollDuration;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);
            if (dodgeTimer >= dodgeRollDuration)
            {
                isDodging = false;
            }
        }
    }
}
