using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickButton : MonoBehaviour
{

    public void OnClick()
    {
        int catPerClick = DataController.GetInstance().GetCatPerClick();
        DataController.GetInstance().AddCat(catPerClick);
        Debug.Log(DataController.GetInstance().GetCat());
    }

    public void Update()
    {
        if(DataController.GetInstance().GetCat() > 1)
        {
            DataController.GetInstance().popCat();///create cat
            DataController.GetInstance().SetCat(0);
        }
    }
}
