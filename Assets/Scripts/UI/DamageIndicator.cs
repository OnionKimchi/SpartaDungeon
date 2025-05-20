using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image; // UI �̹���
    public float flashSpeed; // �����̴� �ӵ�

    private Coroutine coroutine; // �ڷ�ƾ ����
    void Start()
    {
        image.enabled = false; // ���� �� �̹��� ��Ȱ��ȭ
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash; // �÷��̾ ���ظ� ���� �� Flash �޼��� ȣ��
        //��������Ʈ onTakeDamage�� PlayerCondition Ŭ�������� ���ǵ� ��������Ʈ��, ���ظ� ���� �� ȣ��Ǵ� �޼����Դϴ�.
    }
    public void Flash()
    {
        if (coroutine != null) // �ڷ�ƾ�� �̹� ���� ���̸� ����
        {
            StopCoroutine(coroutine);// �ڷ�ƾ �����ϴ� �޼���
        }
        image.enabled = true; // �̹��� Ȱ��ȭ, setActive(true)�� ����, setActive�� �ۼ��Ѵٸ� image.gameObject.SetActive(true);
        image.color = new Color(1f, 100f/255f, 100f/255f, 0.3f); // �̹��� ���� �ʱ�ȭ
        coroutine = StartCoroutine(FadeAway()); // FadeAway �ڷ�ƾ ����
    }

    private IEnumerator FadeAway()// �ڷ�ƾ �޼���
    {
        float startAlpha = 0.3f; // ���� ���� ��
        float a = startAlpha; // ���� ���� ��

        while (a > 0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime; // ���� �� ����
            image.color = new Color(1f, 100f/255f, 100f/255f, a); // �̹��� ���� ������Ʈ
            yield return null; // ���� �����ӱ��� ���
        }

        image.enabled = false; // �̹��� ��Ȱ��ȭ, setActive(false)�� ����, setActive�� �ۼ��Ѵٸ� image.gameObject.SetActive(false);
    }
}
