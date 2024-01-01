using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoScale : MonoBehaviour
{
    public int id;
    public string uuid;
    //public Item item;
    public Text scaleID;
    public Text weight;
    public Text entryDate;
    public Text expiryDate;
    
    // Start is called before the first frame update
    void Awake()
    {
        //item = GetComponentInChildren<Item>();
        scaleID = GetComponentsInChildren<Text>()[1];
        weight = GetComponentsInChildren<Text>()[2];
        entryDate = GetComponentsInChildren<Text>()[3];
        entryDate.text = DateTime.Now.AddDays(UnityEngine.Random.Range(-10, 0)).ToShortDateString();
        expiryDate = GetComponentsInChildren<Text>()[4];
        expiryDate.text = DateTime.Now.AddDays(UnityEngine.Random.Range(1, 10)).ToShortDateString();
        //weight = GetComponentsInChildren<Text>()[4];

        //change size
        scaleID.fontSize = 15;
        weight.fontSize = 15;
        entryDate.fontSize = 15;
        expiryDate.fontSize = 15;

        //change color
        scaleID.color = Color.white;
        weight.color = Color.white;
        entryDate.color = Color.white;
        expiryDate.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        scaleID.text = id.ToString();
    }
}
