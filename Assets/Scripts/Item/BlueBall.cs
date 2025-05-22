using System.Collections; //Enumerator�� ����ϱ� ���� �ʿ��մϴ� .
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)//BlueBall�� Player�� �浹���� ��, ���������� �߰��ϴ� �޼���
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpStack += 1; // ���� ������ 1 ������Ŵ
            }
            // 2�� �Ŀ� �ٽ� Ȱ��ȭ (������Ʈ ��ü�� �ƴ� ������/�ݶ��̴��� ��Ȱ��ȭ�ؾ� 2�� �Ŀ� Ȱ��ȭ�� ��)
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
