using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
