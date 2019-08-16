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

    public GameObject cat;
    public GameObject box;

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
        Instantiate(cat, new Vector3(Random.Range(-4,4), Random.Range(-4, 4), -1), Quaternion.identity);
    }

    public void SetCatPerClick(int newCatPerClick)
    {
        m_catPerClick = newCatPerClick;
        PlayerPrefs.SetInt("CatPerClick", m_catPerClick);
    }
}
