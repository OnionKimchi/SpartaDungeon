using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescriptionUI : MonoBehaviour
{
    public TextMeshProUGUI text;      // UI�� ǥ���� �ؽ�Ʈ ������Ʈ

    // ������ ������ UI�� ǥ���ϴ� �޼���
    public void SetDescription(string title, string description)
    {
        if (text != null)
        { 
            text.text = $"{title}\n{description}"; 
        }
    }

    public void xButtonClick()
    {
        // "ObjectDescription" ������Ʈ�� ã�� ��Ȱ��ȭ
        GameObject descriptionObj = GameObject.Find("ObjectDescription");
        if (descriptionObj != null)
        {
            descriptionObj.SetActive(false);
            Time.timeScale = 1; // ���� �簳
        }
    }
}