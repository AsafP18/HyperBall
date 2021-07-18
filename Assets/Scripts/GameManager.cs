using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[10, 10];
    public GameObject target;
    public GameObject Floor;
    public GameObject RampRoad;
    float zpos;
    float timer;
    float timetrack;
    float deletetimer;
    float deletetimetrack;
    Vector3 pos;
    public static List<GameObject> floorlist;
    bool started;
    int diversitymanager;//makes sure no too many of same platform
    float height;

    // Start is called before the first frame update
    void Start()
    {
        // CreateNewBoard();
        pos = new Vector3(0, 0, 0);
        zpos = 60;
        timer = 3;
        deletetimer = 30;
        deletetimetrack = 15;
        height = -30;
        floorlist = new List<GameObject>();
        CreateFloor();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >timetrack&&PlayerMovement.gamerun==true)
        {
            timetrack =Time.timeSinceLevelLoad+timer;
            CreateFloor();
        }
        if (PlayerMovement.gamerun == false&&Time.timeSinceLevelLoad>deletetimetrack)//if player didn't start the game after a few seconds
            timetrack = Time.timeSinceLevelLoad;
        if(Time.timeSinceLevelLoad>deletetimetrack+5&&PlayerMovement.gamerun==true)//deletes previous platforms
        {
            Destroyfloors(floorlist);
            deletetimetrack = Time.timeSinceLevelLoad + deletetimer;
        }
    }
    public void CreateFloor()
    {
        int selecttype;
        GameObject spawnobj;
        for (int i = 0; i < 20; i++)
        {
            selecttype = Random.Range(0, 7);
            float rndheight = Random.Range(-35f, -42f);//height of platforms
            if (i > 1)
            {
                if(floorlist[i-1].tag==floorlist[i-2].tag)
                {
                    diversitymanager++; 
                }
                if (floorlist[i - 1].tag == "Target")
                    diversitymanager++;
            }
            if(diversitymanager>4)
            {
                diversitymanager = 0;
                if (selecttype > 4)
                    selecttype = 4;
                else if(selecttype<4)
                    selecttype = Random.Range(4, 7);
            }
            if (selecttype < 4)
                spawnobj = Floor;
            else if (selecttype == 4)
            {
                spawnobj = target;
                rndheight -= 5f;
            }
            else
                spawnobj = RampRoad;
            // float nextpos = spawnobj.transform.GetChild(0).transform.localScale.z-3.5f;
            /*   float nextpos = 1.5f;
               float total = nextpos + zpos;
               if (total <= zpos)
                   zpos = total++;
               else
                   zpos = total;*/
            zpos += 40f;
            height += rndheight;
            float xpos = Random.Range(-35f, 35f);
            pos = new Vector3(xpos, height, zpos);
            floorlist.Add( Instantiate(spawnobj, pos, spawnobj.transform.localRotation));
            if (selecttype == 4)//to remove distance between target and next object
                zpos -=5f ;
            //failsafe if first method didn't work
            if (PlayerMovement.GetYpos() < height)
            {
                PlayerMovement.StopGame();
                print("stopped other way"); 
            }
        }
    }
    public void Destroyfloors(List<GameObject> floors)
    {
        for(int i=0;i<10;i++)
        {
            Destroy(floorlist[0]);
            floorlist.RemoveAt(0);
        }
    }

}
