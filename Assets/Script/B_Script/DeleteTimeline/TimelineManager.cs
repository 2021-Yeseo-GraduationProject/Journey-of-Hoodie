using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public GameObject DeleteManager;
    public GameObject Timeline;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        DeleteManager = GameObject.Find("DeleteTimeline");
        Timeline = GameObject.Find("Timeline");  
        Camera = GameObject.Find("Camera");  
     //   TalkPanel = GameObject.Find("TalkPanel");
    }

    // Update is called once per frame
    void Update()
    {
        if (null != DeleteManager){
            if (gameObject.activeSelf == true){
                Timeline.SetActive(false);
                Camera.SetActive(false);
            }
            else{
                return;
            }
        }
        else{
            return;
        }
    }
}
