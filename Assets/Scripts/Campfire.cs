using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int damage; // 데미지
    public float damageRate;// 데미지 주는 속도

    List<IDamageable> things = new List<IDamageable>();//피해를 입힐 수 있는 객체 리스트
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);//지정된 시간 간격으로 DealDamage 메서드 호출
        //인보크리피팅은 지정된 시간 간격으로 메서드를 호출하는 유니티의 내장 메서드(실행할 메서드, 대기 시간, 반복 주기)
    }

    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);//리스트에 있는 객체에 데미지 주기
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out IDamageable damageable))//IDamageable 인터페이스를 구현한 객체인지 확인
            {
                things.Add(damageable);//리스트에 추가
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out IDamageable damageable))//IDamageable 인터페이스를 구현한 객체인지 확인
            {
                things.Remove(damageable);//리스트에서 제거
            }
        }
    }
}
