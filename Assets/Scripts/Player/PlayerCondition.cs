using System;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);//피해를 입는 메서드
}
public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;//UICondition 스크립트의 인스턴스     
    Condition health { get { return uiCondition.health; } }//uiCondition의 health 속성
    Condition stamina { get { return uiCondition.stamina; } }//uiCondition의 stamina 속성

    public event Action onTakeDamage;//피해를 입었을 때 발생하는 이벤트

    // Update is called once per frame
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health의 현재 값에 패시브 값을 시간 당 더함
        stamina.Add(stamina.passiveValue * Time.deltaTime);//stamina의 현재 값에 패시브 값을 시간 당 더함

        if (health.curValue <= 0)//health의 현재 값이 0 이하일 때
        {
            Die();//죽음 처리 함수 호출
        }
    }

    void Die()
    {           
        //죽음 처리 추가 예정
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Add(-damage);//health의 현재 값에 damage를 빼줌
        onTakeDamage?.Invoke();//피해를 입었을 때 발생하는 이벤트 호출, 델리게이트로 해야 확장성 가능
    }
}

