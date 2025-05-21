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
    }

    public void xButtonClick()
    {
        // "ObjectDescription" 오브젝트를 찾아 비활성화
        GameObject descriptionObj = GameObject.Find("ObjectDescription");
        if (descriptionObj != null)
        {
            descriptionObj.SetActive(false);
            Time.timeScale = 1; // 게임 재개
        }
    }
}