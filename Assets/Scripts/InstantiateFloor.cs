using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Floor;
    public GameObject Target;
    Vector3 pos; 
    void Start()
    {
        pos = Floor.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
