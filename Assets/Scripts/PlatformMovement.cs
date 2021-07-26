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
        Speed = Random.Range(-0.2f, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.Translate(Speed, 0, 0);
            if (transform.position.x > 40 || transform.position.x < -40)
                Speed *= -1;
        }
        
    }
}
