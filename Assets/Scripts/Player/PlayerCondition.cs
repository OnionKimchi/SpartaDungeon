using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);//피해를 입는 메서드
}
public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;//UICondition 스크립트의 인스턴스     
    Condition health { get { return uiCondition.health; } }//uiCondition의 health 속성


    [SerializeField] private GameObject DieUI;
    private bool isDead = false;


    public event Action onTakeDamage;//피해를 입었을 때 발생하는 이벤트

    void Start()
    {
        if (DieUI != null)
            DieUI.SetActive(false);//죽은 상태일 때 UI 비활성화
    }
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health의 현재 값에 패시브 값을 시간 당 더함

        if (!isDead && health.curValue <= 0)//health의 현재 값이 0 이하일 때
        {
            Die();//죽음 처리 함수 호출
        }
    }

    void Die()
    {
        if (isDead) return;//이미 죽은 상태라면 함수 종료
        isDead = true;//죽은 상태로 변경
        StartCoroutine(DieRoutine());
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Add(-damage);//health의 현재 값에 damage를 빼줌
        onTakeDamage?.Invoke();//피해를 입었을 때 발생하는 이벤트 호출, 델리게이트로 해야 확장성 가능
    }

    IEnumerator DieRoutine()
    {
        Time.timeScale = 0f;
        DieUI.SetActive(isDead);//죽은 상태일 때 UI 활성화

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

