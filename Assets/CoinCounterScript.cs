using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounterScript : MonoBehaviour
{
    public int coins = 0;
    //public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        //text = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collect()
    {
        coins++;
        gameObject.GetComponent<TMP_Text>().text = "Coins: " + coins;
    }
}
