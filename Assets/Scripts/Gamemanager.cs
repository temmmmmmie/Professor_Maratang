using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public ThrowFood throwfood;
    public GameObject Maratang;
    [Header("Ui")]
    public Transform Remainings;
    public GameObject PleaseDetect;
    public GameObject NoFood;
    [Header("Transforms")]
    public Transform Hand;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        UiRefresh();
    }
    public void Finish()
    {
        string fileName = "MaraTang";
        string path = "Assets/Resources/" + fileName + ".prefab";

        UnityEditor.PrefabUtility.SaveAsPrefabAsset(Maratang, path);
        UnityEditor.AssetDatabase.Refresh();
        SceneManager.LoadScene("Finish");
    }

    void UiRefresh()
    {
        for (int i = 0; i < Remainings.childCount; i++)
        {
            Remainings.GetChild(i).GetComponent<TextMeshProUGUI>().text = Data.instance.data[i].Count.ToString();
            
        }
    }

    public void Useitem(int itemidx)
    {
        Data.instance.data[itemidx].Count--;
        UiRefresh();
    }

    public void Detected()
    {
        PleaseDetect.SetActive(false);
        throwfood.SetFood();
    }
    public void Lost()
    {
        PleaseDetect.SetActive(true);

    }
}
