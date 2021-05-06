using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{


    public GameObject Source;
    //public GameObject AudioManager;
    // Start is called before the first frame update

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag && t.GetChild(i).gameObject.activeSelf)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }
    public void playMusic()
    {
        // 全關閉
        foreach( GameObject go in GameObject.FindGameObjectsWithTag("BGM"))
        {
            if (go.GetComponent<AudioSource>().isPlaying)
                go.GetComponent<AudioSource>().Stop();
        }
        // 播放自己的
        //GameObject temp = FindGameObjectInChildWithTag(AudioManager, "BGM");
        Source.GetComponent<AudioSource>().Play();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
