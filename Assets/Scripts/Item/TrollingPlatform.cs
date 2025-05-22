using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollingPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어가 플랫폼에 닿았을 때, 이 오브젝트를 파괴 합니다.
            Destroy(gameObject);
        }
    }
}
