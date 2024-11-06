using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2D : MonoBehaviour
{
    public Transform Remainings;
    public Sprite[] Crows;
    Vector3 movevec;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Data.instance.Pos;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UiRefresh();
    }

    void UiRefresh()
    {
        for (int i = 0; i < Remainings.childCount; i++)
        {
            Remainings.GetChild(i).GetComponent<TextMeshProUGUI>().text = Data.instance.data[i].Count.ToString();

        }
    }
    public void ToTiTle()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        var Hor = Input.GetAxis("Horizontal");
        var Ver = Input.GetAxis("Vertical");
        movevec.x = Hor;
        movevec.y = Ver;
        gameObject.transform.position += movevec * 0.3f;
        if(Hor > 0)
        {
            spriteRenderer.sprite = Crows[0];
        }
        else if(Hor < 0)
        {
            spriteRenderer.sprite= Crows[1];
        }
        if (Ver > 0)
        {
            spriteRenderer.sprite = Crows[2];
        }
        else if (Ver < 0)
        {
            spriteRenderer.sprite = Crows[3];
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.instance.PlaySound(3);
        }
    }
}
