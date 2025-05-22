using UnityEngine;
using System.Collections; // IEnumerator를 사용하려면 필요합니다.

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
        // 2초 후에 다시 활성화 (오브젝트 전체가 아닌 렌더러/콜라이더만 비활성화)
        StartCoroutine(ReappearAfterDelay());
    }

    private IEnumerator ReappearAfterDelay()
    {
        // 렌더러와 콜라이더 비활성화
        var renderers = GetComponentsInChildren<Renderer>();
        var colliders = GetComponentsInChildren<Collider>();
        foreach (var r in renderers) r.enabled = false;
        foreach (var c in colliders) c.enabled = false;

        yield return new WaitForSeconds(2f);

        foreach (var r in renderers) r.enabled = true;
        foreach (var c in colliders) c.enabled = true;
    }
}