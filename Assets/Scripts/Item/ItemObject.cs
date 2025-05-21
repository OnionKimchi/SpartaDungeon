using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    public string GetInteractPrompt();//상호작용 프롬프트를 반환하는 메서드
    public void OnInteract();//상호작용 메서드

}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;// 아이템 데이터를 저장

    public string GetInteractPrompt()
    {
        return $"{itemData.itemName}\n{itemData.itemDescription}";//아이템 이름과 설명을 문자열로 반환
    }

    public void OnInteract()//상호작용 메서드, 플레이어 인풋 클릭으로 발동
    {
        if (itemData.itemType == ItemType.consumable)
        {
            CharacterManager.Instance.Player.itemData = itemData;//아이템 데이터를 플레이어의 아이템 데이터에 할당
            CharacterManager.Instance.Player.addItem?.Invoke();//아이템 추가 델리게이트 호출
            Destroy(gameObject);//상호작용 후 오브젝트 삭제
        }
        else // 소모품이 아니면 아이템을 줍지 않고 디스크립션 UI를 활성화
        {
            // "ObjectDescription" 오브젝트를 찾아 활성화
            GameObject descriptionObj = GameObject.Find("ObjectDescription");
            if (descriptionObj != null)
            {
                descriptionObj.SetActive(true);
                Time.timeScale = 0;//게임 일시 정지

                // ObjectDescriptionUI 스크립트가 붙어 있다면 정보 전달
                var descUI = descriptionObj.GetComponent<ObjectDescriptionUI>();
                if (descUI != null)
                {
                    descUI.SetDescription(itemData.itemName, itemData.itemDescription);
                }
            }
        }
    }
}
