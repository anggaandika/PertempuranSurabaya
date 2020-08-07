using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlay : MonoBehaviour
{
    public float time;
    public GameObject video ;
    
    void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 0)
        {
            video.SetActive(false);
        }
    }
}
