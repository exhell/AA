using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Stats statsScript;
    // Start is called before the first frame update
    void Awake()
    {
        statsScript = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (statsScript.GetCurrWallet() >= 30)
                Steal();
            else Debug.Log("You must have at least 30 bucks to steal");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            statsScript.DepositWithdrawMoney(1, 100);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            statsScript.DepositWithdrawMoney(0, 100);
        }
        
    }

    void Steal()
    {
        if (Random.Range(0, 10)<5)
        {
            //loose
            statsScript.alterWallet(-30);
        }
        else
        {
            //win
            statsScript.alterWallet(Random.Range(10,100));
        }
    }

 
}
