using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlay : MonoBehaviour
{
    public float time;
    public GameObject video;
    public DialougManager dialoug;
    
    void Update()
    {
        time -= Time.deltaTime;
        if (video != null)
        {
            if (time <= 0)
            {
                video.SetActive(false);
            }

        }
    }
}