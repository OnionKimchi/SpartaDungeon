using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);//���ظ� �Դ� �޼���
}
public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;//UICondition ��ũ��Ʈ�� �ν��Ͻ�     
    Condition health { get { return uiCondition.health; } }//uiCondition�� health �Ӽ�


    [SerializeField] private GameObject DieUI;
    private bool isDead = false;


    public event Action onTakeDamage;//���ظ� �Ծ��� �� �߻��ϴ� �̺�Ʈ

    void Start()
    {
        if (DieUI != null)
            DieUI.SetActive(false);//���� ������ �� UI ��Ȱ��ȭ
    }
    void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);//health�� ���� ���� �нú� ���� �ð� �� ����

        if (!isDead && health.curValue <= 0)//health�� ���� ���� 0 ������ ��
        {
            Die();//���� ó�� �Լ� ȣ��
        }
    }

    void Die()
    {
        if (isDead) return;//�̹� ���� ���¶�� �Լ� ����
        isDead = true;//���� ���·� ����
        StartCoroutine(DieRoutine());
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Add(-damage);//health�� ���� ���� damage�� ����
        onTakeDamage?.Invoke();//���ظ� �Ծ��� �� �߻��ϴ� �̺�Ʈ ȣ��, ��������Ʈ�� �ؾ� Ȯ�强 ����
    }

    IEnumerator DieRoutine()
    {
        Time.timeScale = 0f;
        DieUI.SetActive(isDead);//���� ������ �� UI Ȱ��ȭ

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

