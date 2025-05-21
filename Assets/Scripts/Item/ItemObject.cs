using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    public void OnInteract();//��ȣ�ۿ� �޼���

}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;// ������ �����͸� ����
    public ObjectDescriptionUI descriptionUI;
    public void OnInteract()
    {
        if (itemData.onInteractAction != null)
        {
            itemData.onInteractAction(this);
        }
        else
        {
            Debug.LogWarning("onInteractAction�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }

    void Awake()
    {
        if (itemData.onInteractAction == null)
        {
            switch (itemData.itemType)
            {
                case ItemType.consumable:
                    itemData.onInteractAction = (itemObj) => {
                        CharacterManager.Instance.Player.itemData = itemObj.itemData;
                        CharacterManager.Instance.Player.addItem?.Invoke();
                        Destroy(itemObj.gameObject);
                    };
                    break;
                case ItemType.jumpItem:
                    itemData.onInteractAction = (itemObj) => {
                        var effect = itemObj.GetComponent<JumpItemEffect>();
                        if (effect != null)
                        {
                            effect.ApplyJump(CharacterManager.Instance.Player.gameObject);
                        }
                    };
                    break;
            }
        }
    }

    void OnMouseEnter()
    {
        if (descriptionUI != null)
        {
            descriptionUI.gameObject.SetActive(true);
            descriptionUI.SetDescription(itemData.itemName, itemData.itemDescription);
        }
    }

    void OnMouseExit()
    {
        if (descriptionUI != null)
        {
            descriptionUI.gameObject.SetActive(false);
        }
    }
}
