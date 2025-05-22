using UnityEngine;
using System.Collections; // IEnumerator�� ����Ϸ��� �ʿ��մϴ�.

public class RadBall : MonoBehaviour
{
    public float jumpPower = 80f;

     public void ApplyJump(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0;
            rb.velocity = velocity;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        // 2�� �Ŀ� �ٽ� Ȱ��ȭ (������Ʈ ��ü�� �ƴ� ������/�ݶ��̴��� ��Ȱ��ȭ)
        StartCoroutine(ReappearAfterDelay());
    }

    private IEnumerator ReappearAfterDelay()
    {
        // �������� �ݶ��̴� ��Ȱ��ȭ
        var renderers = GetComponentsInChildren<Renderer>();
        var colliders = GetComponentsInChildren<Collider>();
        foreach (var r in renderers) r.enabled = false;
        foreach (var c in colliders) c.enabled = false;

        yield return new WaitForSeconds(2f);

        foreach (var r in renderers) r.enabled = true;
        foreach (var c in colliders) c.enabled = true;
    }
}