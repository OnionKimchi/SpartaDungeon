using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescriptionUI : MonoBehaviour
{
    public TextMeshProUGUI text;      // UI에 표시할 텍스트 컴포넌트

    // 아이템 정보를 UI에 표시하는 메서드
    public void SetDescription(string title, string description)
    {
        if (text != null)
        {
            text.text = $"{title}\n{description}";
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI 컴포넌트가 할당되지 않았습니다.");
        }
    }
}