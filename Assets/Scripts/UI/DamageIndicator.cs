using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image; // UI 이미지
    public float flashSpeed; // 깜빡이는 속도

    private Coroutine coroutine; // 코루틴 변수
    void Start()
    {
        image.enabled = false; // 시작 시 이미지 비활성화
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash; // 플레이어가 피해를 입을 때 Flash 메서드 호출
        //델리게이트 onTakeDamage는 PlayerCondition 클래스에서 정의된 델리게이트로, 피해를 입을 때 호출되는 메서드입니다.
    }
    public void Flash()
    {
        if (coroutine != null) // 코루틴이 이미 실행 중이면 중지
        {
            StopCoroutine(coroutine);// 코루틴 중지하는 메서드
        }
        image.enabled = true; // 이미지 활성화, setActive(true)와 동일, setActive로 작성한다면 image.gameObject.SetActive(true);
        image.color = new Color(1f, 100f/255f, 100f/255f, 0.3f); // 이미지 색상 초기화
        coroutine = StartCoroutine(FadeAway()); // FadeAway 코루틴 시작
    }

    private IEnumerator FadeAway()// 코루틴 메서드
    {
        float startAlpha = 0.3f; // 시작 알파 값
        float a = startAlpha; // 현재 알파 값

        while (a > 0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime; // 알파 값 감소
            image.color = new Color(1f, 100f/255f, 100f/255f, a); // 이미지 색상 업데이트
            yield return null; // 다음 프레임까지 대기
        }

        image.enabled = false; // 이미지 비활성화, setActive(false)와 동일, setActive로 작성한다면 image.gameObject.SetActive(false);
    }
}
