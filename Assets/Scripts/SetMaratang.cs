using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetMaratang : MonoBehaviour
{
    GameObject Realmara;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 0.05f);
    }
    void Delay()
    {
        var load = Resources.Load("MaraTang") as GameObject;
        Realmara = Instantiate(load);
        Realmara.transform.position = new Vector3(0, 0.8934444f, -9.2634f);
        Realmara.transform.rotation = Quaternion.Euler(-45, 0, 0);
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");

    }
}
