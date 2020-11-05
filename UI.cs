using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private Image expBar;
    [SerializeField] private Image bankBar;
    [SerializeField] private Image energyBar;
    [SerializeField] private Image hungerBar;




    void Start()
    {
        inventoryMenu.SetActive(false);
    }
    void Update()
    {
        InventoryOpener();
    }


    void InventoryOpener()
    {
        if (Input.GetKeyDown(KeyCode.I))           //open / close inventory
        {
            if (inventoryMenu.activeInHierarchy)
                inventoryMenu.SetActive(false);
            else inventoryMenu.SetActive(true);
        }
    }



    public void alterExpBar(int exp,int maxExp)
    {
        //expBar.rectTransform.sizeDelta = new Vector2(exp / maxExp * 200, 6.17f);
        //expBar.rectTransform.rect.Set(expBar.rectTransform.rect.x, expBar.rectTransform.rect.y, exp / maxExp * 200, expBar.rectTransform.rect.height);
        expBar.transform.localScale = new Vector2(exp / maxExp, 1);
        Debug.Log(maxExp);
    }
}
