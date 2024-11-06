using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ThrowFood : MonoBehaviour
{
    public Transform camTr;
    public Transform Maratang;
    public int Curitem;

    public bool NoFood;
    ParticleSystem particlesys;
    Rigidbody rb;
    Vector3 mousepos;
    Vector3 Firstpos = new Vector3(0, 0, 0.3f);
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetFood()
    {
        var data = Data.instance.data;
        List<int> ValidIdx = new List<int>();
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].Count > 0) ValidIdx.Add(i);
        }
        if (ValidIdx.Count == 0)
        {
            NoFood = true;
            Gamemanager.instance.NoFood.SetActive(true);
            return;
        }
            Curitem = ValidIdx[ Random.Range(0, ValidIdx.Count)];
        var food = Instantiate(data[Curitem].prefab, Gamemanager.instance.Hand);
        particlesys = food.GetComponentInChildren<ParticleSystem>();
    }

    private void LateUpdate()
    {
        if (rb == null || rb.isKinematic == false || NoFood) return;
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 deltaPos = mousepos - Input.mousePosition;
            float len = deltaPos.magnitude;

            rb.isKinematic = false;
            rb.AddForce((camTr.forward + camTr.up).normalized * len * 0.3f);
            rb.AddTorque(-deltaPos.y, deltaPos.x, 0);

            Gamemanager.instance.Useitem(Curitem);
            Invoke("ResetFood", 2);
        }

    }

    private void ResetFood()
    {
        if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        rb.isKinematic = true;
        transform.localPosition = Firstpos;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        SetFood();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            rb.isKinematic = true;
            particlesys.Play();
            AudioManager.instance.PlaySound(2);
            if (transform.childCount > 0) transform.GetChild(0).SetParent(Maratang);
        }

    }
}
