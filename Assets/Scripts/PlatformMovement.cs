using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    private void Awake()
    {
        int type = Random.Range(0, 2);
        Speed = Random.Range(-0.1f, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed, 0, 0);
        if (transform.position.x > 20 || transform.position.x < -20)
            Speed *= -1;
        
    }
}