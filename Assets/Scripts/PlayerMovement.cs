using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool gamerun;//bool when started game
    public float forwardspeed;
    public float movementspeed;// ball movement on x axis
    public float zvector;// z moving force
    public float yvector;
    Vector3 Playermove;
    Vector3 Dir;
    static Rigidbody rb;
    Vector3 movementposcam;
    float fallmultiplier;
    float airfallmultiplier;
    float speedupmulitplier;
    Touch touch;
    //sound
    public AudioClip jumpclip;
    public AudioClip RampClip;
    bool isplaying;
    AudioSource source;
    GameObject taptext;
    int deathcount;//how many passed back boxes
    //score
    public int airbonus;//bonus score for staying in air
    public ScoreManager SCmanager;

    // Start is called before the first frame update
    void Start()
    {
        gamerun = false;
        forwardspeed = 60;
        movementspeed = 5;
        rb = GetComponent<Rigidbody>();
        airbonus = 0;
        zvector = 0.6f;
        yvector = -1.35f;
        fallmultiplier = 11;
        airfallmultiplier = 14;
        speedupmulitplier = 5f;
        source = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        taptext = GameObject.Find("TapText");

    }

    // Update is called once per frame
    void Update()
    {
        movementposcam = Camera.main.WorldToViewportPoint(transform.position);
        Playermove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
    private void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.S) || Input.touchCount > 0) && gamerun == false)
        {
            gamerun = true;//starting game by touch
            rb.velocity = Vector3.forward * forwardspeed;//continuous movement start
            Destroy(taptext);
        }

        if (gamerun == true)
        {
            /*if (istouching)
                Dir = new Vector3(0, yvector+1.35f, zvector-1);
            else
                Dir = new Vector3(0, yvector, zvector);
            rb.velocity = Dir * forwardspeed;*/
            //makes sure ball doens't move continously after a side collision 
            if (rb.velocity.x > 0)
                rb.velocity += Vector3.left * 3;

            else if (rb.velocity.x < 0)
            {
                rb.velocity += Vector3.right * 3;
            }
            if (rb.velocity.z < 60)// makes sure ball doesn't slow down after collision
                rb.velocity += Vector3.forward * 5;
            if (rb.velocity.z > 110)//makes sure ball doesn't speed up too much
                rb.velocity -= Vector3.forward * 5;
            //falling mechanic
            if (rb.velocity.y < 0 && rb.velocity.y > -90)
                rb.velocity += Vector3.up * Physics.gravity.y * (airfallmultiplier - 1) * Time.deltaTime;
            else if (rb.velocity.y > 0)
                rb.velocity += Vector3.up * Physics.gravity.y * (airfallmultiplier - 1) * Time.deltaTime;
            else
                rb.velocity += Vector3.up * Physics.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
            //moving mechanic
            rb.MovePosition(transform.position + (Playermove * 50 * Time.deltaTime));
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    rb.MovePosition(transform.position + (new Vector3(touch.deltaPosition.x, 0, 0) * movementspeed * Time.deltaTime));
                }
            }
        }
    }
    IEnumerator Speedup()
    {

        rb.AddForce(transform.forward * speedupmulitplier + Vector3.down * 5, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        rb.velocity -= Vector3.forward * speedupmulitplier;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 40);

        }
        else if (other.gameObject.tag == "Arrow")
        {
            StartCoroutine(Speedup());
        }
        if (other.gameObject.tag == "FallBox")
        {
            deathcount++;
            if (deathcount > 1)
            {
                StartCoroutine("StopGameDelay");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopAirBonus();
        if (collision.gameObject.tag == "Target" && isplaying == false)
            StartCoroutine(PlaySound(RampClip));
        else if (collision.gameObject.tag != "Ramp" && isplaying == false)
            StartCoroutine(PlaySound(jumpclip));
    }
    public void OnCollisionExit(Collision collision)
    {
        InvokeRepeating("AddAirBonus", 2.2f, 0.2f);
        if (collision.gameObject.tag == "Ramp")
        {
            rb.AddForce(transform.forward + Vector3.up * 3 * speedupmulitplier, ForceMode.Impulse);
            source.PlayOneShot(RampClip);
        }
    }
    IEnumerator PlaySound(AudioClip clip)
    {
        isplaying = true;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(1);
        isplaying = false;
    }    
    void AddAirBonus()
    {
        airbonus += 25;
    }
    void StopAirBonus()
    {
        CancelInvoke();
        SCmanager.StartCoroutine("AddAirScore", airbonus);
        airbonus = 0;
    }
    

    public static float GetYpos()
    {
        return rb.position.y;
    }
    public IEnumerator StopGameDelay()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
        ScoreManager.OpenLosePanel();
    }
    public static void StopGame()
    {
        Time.timeScale = 0;
        ScoreManager.OpenLosePanel();
    }
}
