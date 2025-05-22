using System.Collections; //Enumerator를 사용하기 위해 필요합니다 .
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//BlueBall이 Player와 충돌했을 때, 점프스택을 추가하는 메서드
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpStack += 1; // 점프 스택을 1 증가시킴
            }
            // 2초 후에 다시 활성화 (오브젝트 전체가 아닌 렌더러/콜라이더만 비활성화해야 2초 후에 활성화가 됨)
            StartCoroutine(ReappearAfterDelay());
        }
    }
    private IEnumerator ReappearAfterDelay()
    {
        var renderers = GetComponentsInChildren<Renderer>();
        var colliders = GetComponentsInChildren<Collider>();
        foreach (var r in renderers) r.enabled = false;
        foreach (var c in colliders) c.enabled = false;

        yield return new WaitForSeconds(2f);

        foreach (var r in renderers) r.enabled = true;
        foreach (var c in colliders) c.enabled = true;
    }
}
