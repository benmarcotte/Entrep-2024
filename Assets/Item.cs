using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;
    public DateTime entry;
    public DateTime expiry;
    // Start is called before the first frame update
    void Start()
    {
        entry = DateTime.Now;
        expiry = DateTime.Now.Add(new TimeSpan(7, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
