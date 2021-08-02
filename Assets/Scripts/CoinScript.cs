using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    ScoreManager SCmanager;
    // Start is called before the first frame update
    private void Awake()
    {
        SCmanager = GameObject.Find("Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        SCmanager.StartCoroutine("AddCoinBonus");
        Destroy(gameObject);
    }
}
