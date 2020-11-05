using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private string name = "Some item";
    private string description = "This is an item, parent class of all items. I can be instantiated and destroyed, but never found in game.";
    
    public abstract void Consume();
}
