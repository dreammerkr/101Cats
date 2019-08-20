using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    public enum function
    {
        BoxUI,
        BoxSelect0,
        BoxSelect1,
        BoxSelect2,
        BoxSelect3
    }

    [Header("클릭 시 실행될 함수")]
    public function functionName;

    void Start()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);
    }

    void OnPointerDown(PointerEventData data)
    {
        SelectFunction();
    }

    void SelectFunction()
    {
        switch (functionName)
        {
            case function.BoxUI:
                BoxUI();
                break;
            case function.BoxSelect0:
                BoxSelect(0);
                break;
            case function.BoxSelect1:
                BoxSelect(1);
                break;
            case function.BoxSelect2:
                BoxSelect(2);
                break;
            case function.BoxSelect3:
                BoxSelect(3);
                break;
        }
    }

    void BoxUI()
    {
        if (!GameManager.instance.openBoxUI)
        {
            GameManager.instance.openBoxUI = true;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            GameManager.instance.openBoxUI = false;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void BoxSelect(int num)
    {
        DataController.GetInstance().box_num = num;
        GameManager.instance.box.GetComponent<SpriteRenderer>().sprite = GameManager.instance.box_sprites[num];
    }
}
