using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FoodFound : MonoBehaviour
{
    public FoodType type;
    public int id;
    private void Start()
    {
        if(Data.instance.FoundFoodIdx.Contains(id)) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlaySound(2);
        Data.instance.FoundFoodType = (int)type;
        Data.instance.FoundFoodIdx.Add(id);
        Data.instance.Pos =  collision.gameObject.transform.position;
        SceneManager.LoadScene("Getfood");
    }
}
