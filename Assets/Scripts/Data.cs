
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum itemtype
{
    Professor,
    Cucumber,
    Garlic,
    Meat1,
    Meat2,
    Onion,
    Zuccini
}
public enum FoodType
{
    Vegetables,
    Meat,
    Professor
}
[System.Serializable]
public class item
{
    public itemtype itemtype;
    public uint Count;
    public GameObject prefab;
}
public class Data : MonoBehaviour
{
    public static Data instance;
    public List<item> data;
    [Header("GetFood")]
    public int FoundFoodType;
    public List<int> FoundFoodIdx;
    public Vector2 Pos;
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void SceneChange(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

}
