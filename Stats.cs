using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private UI UIScript;
    private int maxBank;
    private int currWallet;
    private int currBank;
    private int level;
    private int exp;
    private int maxExp;
    private int hunger;
    private int energy;



    void Start()
    {
        currWallet = PlayerPrefs.GetInt("currWallet", 100);             //get wallet from file
        level = PlayerPrefs.GetInt("Level", 1);                         //get level from file
        exp = PlayerPrefs.GetInt("Exp", 0);                             //get exp from file
        maxExp = PlayerPrefs.GetInt("MaxExp", level * level * 100);     //get MaxExp from file
        currBank = PlayerPrefs.GetInt("CurrBank", 0);                   //get CurrBank from file
        maxBank = PlayerPrefs.GetInt("MaxBank", 500);                   //get MaxBank from file
        UIScript.alterExpBar(exp, maxExp);
    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debuging();
        }
        else if (Input.GetKeyDown(KeyCode.R))
            ResetStats();
    }


    public int GetCurrWallet() { return currWallet; }


    void ResetStats()                     //Resets stats
    {
        currWallet = 100;
        level = 1;
        exp = 0;
        currBank = 0;
        maxBank = 500;
        maxExp = level * level * 100;
        PlayerPrefs.SetInt("currWallet", 100);            
        PlayerPrefs.SetInt("Level", 1);                        
        PlayerPrefs.SetInt("Exp", 0);                             
        PlayerPrefs.SetInt("CurrBank", 0);                   
        PlayerPrefs.SetInt("MaxBank", 500);
        PlayerPrefs.SetInt("MaxExp", level * level * 100);
    }

    void Debuging()                         //Debugs values
    {
        Debug.ClearDeveloperConsole();
        Debug.Log("Bank " + currBank + " / " + maxBank);
        Debug.Log("wallet " + currWallet);
        Debug.Log("Level " + level);
        Debug.Log("Exp " + exp + " / " + maxExp);
    }



    public void alterWallet(int amount)             //Changes wallet value
    {
        currWallet += amount;
        if (amount > 0)
            AlterExp(amount / 2);
        else AlterExp(5);
        CheckForLevelUp();

        //call UI script here
        PlayerPrefs.SetInt("currWallet", currWallet);             
        
    }



    void AlterExp(int x) 
    { 
        exp += x;
        PlayerPrefs.SetInt("Exp", exp);
        UIScript.alterExpBar(exp, maxExp);
    }



    void CheckForLevelUp()                          //checks if level up
    {
        if (exp >= maxExp)
        {
            Debug.Log("LEVEL UP!");
            exp = exp - maxExp;
            level += 1;
            maxExp = level * level * 100;
            maxBank += 500;
            PlayerPrefs.SetInt("Exp", exp);
            PlayerPrefs.SetInt("MaxExp", maxExp);
            PlayerPrefs.SetInt("MaxBank", maxBank);                 
            PlayerPrefs.SetInt("Level", level);                        
        }
    }



    public void DepositWithdrawMoney(int depoWith, int amount)       //Deposit/withdraw bank
    {
        if(depoWith ==1)        //deposit
        {
            if (amount <= currWallet)
            {
                if (currBank < maxBank)
                {
                    if (currBank + amount <= maxBank)
                    {
                        currWallet -= amount;
                        currBank += amount;
                    }
                    else
                    {
                        currWallet -= maxBank - currBank;
                        currBank = maxBank;
                    }
                }
                else Debug.Log("Bank full kiddo");
            }
            else Debug.Log("you're broke lol");
        }
        else                    //withdraw
        {
            if (amount <= currBank)
            {
                currBank -= amount;
                currWallet += amount;
            }
            else Debug.Log("you're broke lol");
        }
        PlayerPrefs.SetInt("CurrBank", currBank);           
    } 



    
}
