using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = transform.GetChild(3).GetComponent<ParticleSystem>();
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("ParticleFunc", collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "bigjump")
            StartCoroutine("ParticleFunc",other.gameObject);
    }
    public IEnumerator ParticleFunc(GameObject hitobj)
    {
        particles.Play();
        particles.startColor = hitobj.gameObject.GetComponent<Renderer>().material.color;
        yield return new WaitForSeconds(0.2f);
        particles.Stop();
    }
}
