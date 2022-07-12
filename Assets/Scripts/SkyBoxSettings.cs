using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxSettings : MonoBehaviour
{
    [SerializeField] private Material sky1, sky2, sky3;
    private void Start()
    {
        var rnd = Random.Range(0, 4);
        if(rnd == 1)
        {
            RenderSettings.skybox = sky1;
        }
        else if(rnd == 2)
        {
            RenderSettings.skybox = sky2;
        }
        else if (rnd == 3)
        {
            RenderSettings.skybox = sky3;
        }
        else
        {
            RenderSettings.skybox = sky1;
        }
    }
}
