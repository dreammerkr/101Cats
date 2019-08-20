using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;

    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("DataConroller");
                instance = container.AddComponent<DataController>();
            }
        }

        return instance;
    }

    private int m_cat = 0;
    private int m_catPerClick = 0;

    public int box_num = 0;

    public GameObject[] cats = new GameObject[4];
    public GameObject box;

    [Header("기본 박스 덜흔함 고양이 등장 확률")]
    public int basic_box_percent;
    [Header("귤 박스 흔함 고양이 등장 확률")]
    public int gyul_box_percent0;
    [Header("귤 박스 희귀 고양이 등장 확률")]
    public int gyul_box_percent1;
    [Header("말끔한 박스 흔함 고양이 등장 확률")]
    public int mal_box_percent0;
    [Header("말끔한 박스 희귀 고양이 등장 확률")]
    public int mal_box_percent1;
    [Header("말끔한 박스 특별 고양이 등장 확률")]
    public int mal_box_percent2;
    [Header("럭셔리 박스 덜흔함 고양이 등장 확률")]
    public int lux_box_percent0;
    [Header("럭셔리 박스 특별 고양이 등장 확률")]
    public int lux_box_percent1;

    void Awake()
    {
        // Key : Value, Key is not valid, value = 0
        m_cat = PlayerPrefs.GetInt("Cat");
        m_catPerClick = PlayerPrefs.GetInt("CatPerClick", 1);
    }

    public void SetCat(int newCat)
    {
        m_cat = newCat;
        PlayerPrefs.SetInt("Cat", m_cat);
    }

    public void AddCat(int newCat)
    {
        m_cat += newCat;
        SetCat(m_cat);
    }

    public int GetCat()
    {
        return m_cat;
    }

    public int GetCatPerClick()
    {
        return m_catPerClick;
    }

    public void popCat()
    {
        int cat_pop_num = Random.Range(0, 100);
        switch (box_num)
        {
            case 0:
                if (cat_pop_num >= 100 - basic_box_percent)
                {
                    Instantiate(cats[1], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                } else
                {
                    Instantiate(cats[0], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                break;
            case 1:
                if (cat_pop_num >= 100 - gyul_box_percent1)
                {
                    Instantiate(cats[2], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else if (cat_pop_num < gyul_box_percent0)
                {
                    Instantiate(cats[0], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else
                {
                    Instantiate(cats[1], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                break;
            case 2:
                if (cat_pop_num >= 100 - mal_box_percent2)
                {
                    Instantiate(cats[3], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else if ((cat_pop_num < 100 - mal_box_percent2) && (cat_pop_num >= 100 - mal_box_percent1 - mal_box_percent2))
                {
                    Instantiate(cats[2], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else if (cat_pop_num < mal_box_percent0)
                {
                    Instantiate(cats[0], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else
                {
                    Instantiate(cats[1], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                break;
            case 3:
                if (cat_pop_num >= 100 - lux_box_percent1)
                {
                    Instantiate(cats[3], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else if (cat_pop_num < lux_box_percent0)
                {
                    Instantiate(cats[1], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                else {
                    Instantiate(cats[2], new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1), Quaternion.identity);
                }
                break;
        }
    }

    public void SetCatPerClick(int newCatPerClick)
    {
        m_catPerClick = newCatPerClick;
        PlayerPrefs.SetInt("CatPerClick", m_catPerClick);
    }
}
