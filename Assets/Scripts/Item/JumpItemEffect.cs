using UnityEngine;

public class JumpItemEffect : MonoBehaviour
{
    public float jumpPower = 80f;

    public void ApplyJump(GameObject player)
    {
        var rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0;
            rb.velocity = velocity;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}