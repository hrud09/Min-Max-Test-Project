using UnityEngine;

public class AnimationManager : MonoBehaviour
{
 
    public Rigidbody rb; // Reference to the Rigidbody component

    private float moveThreshold = 0.1f; // Threshold to determine if the player is moving

    private void Update()
    {
        // Calculate the normalized speed of the character
        float speed = rb.velocity.magnitude * moveThreshold;

        // Clamp the speed between 0 and 1
        speed = Mathf.Clamp01(speed);

        // Set the "Speed" parameter in the Animator Controller
       // animator.SetFloat("Speed", speed);
    }
}
