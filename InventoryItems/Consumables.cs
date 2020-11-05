using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Consumables : Item
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Consume()
    {
        Destroy(this.gameObject);
        Debug.Log("you have been eaten");
    }
}