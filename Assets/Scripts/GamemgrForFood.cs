using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemgrForFood : MonoBehaviour
{
    [Header("UI")]
    public GameObject PleaseDetect;
    public GameObject CropInfo;
    public GameObject AnimalInfo;
    public GameObject ProfessorInfo;
    public GameObject Finished_UI;
    [Header("ETC")]
    public Camera ArCam;
    public GameObject Crops;
    public GameObject Animals;
    public GameObject Farm;
    public GameObject Office;

    GameObject CurItem;
    int CropCount;
    public int AnimalCount;
    public int ProfessorCount;
    bool Finished;
    private void Start()
    {
        CropCount = 0;
        AnimalCount = 0;
        switch(Data.instance.FoundFoodType)
        {
            case 0:
                Farm.SetActive(true);
                Crops.SetActive(true);
                break;
            case 1:
                Farm.SetActive(true);
                Animals.SetActive(true);
                break;
            case 2:
                Office.SetActive(true);
                break;
        }
    }
    private void Update()
    {
        if (CropCount > 3 || AnimalCount > 4 || ProfessorCount > 0)
        {
            CropInfo.SetActive(false);
            AnimalInfo.SetActive(false);
            ProfessorInfo.SetActive(false);
            Finished_UI.SetActive(true); 
            Finished = true;
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (Finished) {
                switch (Data.instance.FoundFoodType)
                {
                    case 0:
                        Data.instance.data[Random.Range(1, 5)].Count++;
                        break;
                    case 1:
                        Data.instance.data[Random.Range(5, 7)].Count++;
                        break;
                    case 2:
                        Data.instance.data[0].Count++;
                        break;
                }
                SceneManager.LoadScene("FoodMap"); 
            }
            var ray = ArCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Food")))
            {
                CurItem = hit.collider.gameObject;
                hit.collider.enabled = false;
                switch (Data.instance.FoundFoodType)
                {
                    case 0:
                        CurItem.GetComponent<Animation>().Play();
                        AudioManager.instance.PlaySound(0);
                        CropCount++;
                        Invoke("Additem", 0.3f);
                        break;
                    case 1:
                        CurItem.GetComponentInParent<Animator>().SetBool("Die", true);
                        AudioManager.instance.PlaySound(0);
                        AnimalCount++;
                        Invoke("Additem", 0.3f);
                        break;
                    case 2:
                        CurItem.GetComponentInParent<Animator>().SetBool("Die", true);
                        AudioManager.instance.PlaySound(1);
                        ProfessorCount++;
                        Invoke("Additem", 0.3f);
                        break;
                }
            }
        }
        
    }
    public void Additem()
    {
        CurItem.SetActive(false);

    }
    public void Detected()
    {
        PleaseDetect.SetActive(false);
        if(Finished)
            Finished_UI.SetActive(true);
        else
            switch (Data.instance.FoundFoodType)
            {
                case 0:
                    CropInfo.SetActive(true);
                    break;
                case 1:
                    AnimalInfo.SetActive(true);
                    break;
                case 2:
                    ProfessorInfo.SetActive(true);
                    break;
            }
    }
    public void Lost()
    {
        PleaseDetect.SetActive(true);
        Finished_UI.SetActive(false);
        CropInfo.SetActive(false);
        AnimalInfo.SetActive(false);
        ProfessorInfo.SetActive(false);
    }
}
