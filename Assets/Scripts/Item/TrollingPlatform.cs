using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollingPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾ �÷����� ����� ��, �� ������Ʈ�� �ı� �մϴ�.
            Destroy(gameObject);
        }
    }
}
