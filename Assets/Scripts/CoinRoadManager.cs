using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    int SpawnCoin;
    private void Awake()
    {
        SpawnCoin = Random.Range(1, 4);
        if (SpawnCoin > 1)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Coin")
                    Destroy(child.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
