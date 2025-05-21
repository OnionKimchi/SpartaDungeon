using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
