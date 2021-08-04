using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
#if Unity_IOS
    string gameId="4247202";
#else
    string gameId = "4247203";
#endif
   static int addcounter = 0;//makes add every other game
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
    }
    public void PlayAd()
    {
        if (addcounter == 0)
        {
            addcounter++;
            if (gameId == "4247203" && Advertisement.IsReady("Interstitial_Android"))
                Advertisement.Show("Interstitial_Android");
            else if (gameId == "4247202" && Advertisement.IsReady("Interstitial_iOS"))
                Advertisement.Show("Interstitial_iOS");
        }
        else if (addcounter == 1)
            addcounter = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
