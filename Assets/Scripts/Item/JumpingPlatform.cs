using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    public float jumpPower; // 튀어오르는 힘

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 기존 Y속도를 0으로 초기화 후 힘을 가함 (더 자연스러운 점프가 된다고 함)
                Vector3 velocity = rb.velocity;
                velocity.y = 0;
                rb.velocity = velocity;
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
