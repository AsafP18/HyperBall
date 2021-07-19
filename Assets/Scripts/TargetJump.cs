using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetJump : MonoBehaviour
{
    float jumpforce;
    GameObject player;
    Vector3 dir;
    // Start is called before the first frame update
    void awake()
    {
        jumpforce = 1000;
        dir = transform.TransformDirection(Vector3.up * jumpforce+Vector3.forward*40);
        print(dir.z);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject;
        player.GetComponent<Rigidbody>().AddForce(dir*jumpforce*10, ForceMode.Acceleration);
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        player.GetComponent<Rigidbody>().AddForce(dir *jumpforce*100, ForceMode.Acceleration);
    }
}
