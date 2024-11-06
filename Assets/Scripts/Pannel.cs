using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pannel : MonoBehaviour
{
    public GameObject Textbox;
    [TextArea]
    public string WrittenText;
    TextMeshProUGUI Text;
    private void Start()
    {
        Text = Textbox.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Textbox.gameObject.SetActive(true);
        Text.text = WrittenText;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Textbox.gameObject.SetActive(false);
    }
}
