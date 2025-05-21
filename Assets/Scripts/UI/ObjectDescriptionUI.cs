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
        else
        {
            Debug.LogWarning("TextMeshProUGUI ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
}