using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    public float jumpPower; // Ƣ������� ��

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // ���� Y�ӵ��� 0���� �ʱ�ȭ �� ���� ���� (�� �ڿ������� ������ �ȴٰ� ��)
                Vector3 velocity = rb.velocity;
                velocity.y = 0;
                rb.velocity = velocity;
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
