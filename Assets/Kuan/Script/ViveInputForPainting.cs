using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR; 
using Valve.VR.Extras; 
public class ViveInputForPainting : MonoBehaviour
{ 
    // 顯示在Unity Inspector
    [SerializeField]
    private float rightHandForce;
    [SerializeField]
    private float leftHandForce;
     
    //讀取左右手
    public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag && t.GetChild(i).gameObject.activeSelf )
            {
                 return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

        // 讀取數值
        rightHandForce = SteamVR_Actions._default.Squeeze.GetAxis(RightInputSource);
        leftHandForce = SteamVR_Actions._default.Squeeze.GetAxis(LeftInputSource);

        // 找手上的噴槍

        if (rightHandForce >0.0f　)
        {

            GameObject go = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "HVLP");
            if (go != null)
            {
                // 查剩餘時間 有時間扣時間 沒時間就關閉
                if (go.GetComponent<ItemWorld>().remainingTime > 0)
                {
                    go.GetComponent<ItemWorld>().remainingTime--; 

                    if (!go.GetComponentInChildren<ParticleSystem>().isPlaying)
                        go.GetComponentInChildren<ParticleSystem>().Play();
                    if (!go.GetComponentInChildren<AudioSource>().isPlaying)
                        go.GetComponentInChildren<AudioSource>().Play();
                }
                else if(go.GetComponent<ItemWorld>().remainingTime == 0)
                {
                    go.GetComponentInChildren<ParticleSystem>().Stop(); 
                    go.GetComponentInChildren<AudioSource>().Stop();
                    Debug.Log("噴槍用盡" + go.name);
                    if (!GameObject.Find("噴槍用盡").GetComponent<AudioSource>().isPlaying)
                        GameObject.Find("噴槍用盡").GetComponent<AudioSource>().Play();


                }
                // 顯示時間
                GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>().text = " " + (go.GetComponent<ItemWorld>().remainingTime / 30) + "s";
            }
        }　else if (rightHandForce == 0 )
        {
            GameObject go = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "HVLP");
            if (go != null)
            {
                go.GetComponentInChildren<ParticleSystem>().Stop();
                go.GetComponentInChildren<AudioSource>().Stop();
            }
        }
        
       


        // 強制更新P3dVrmanager Trigger狀態
        //GetComponent<PaintIn3D.P3dVrManager>().RightTrigger = (rightHandForce > 0.0f)? true: false;
        //GetComponent<PaintIn3D.P3dVrManager>().LeftTrigger = (leftHandForce > 0.0f) ? true : false;


        /* 測試抓Color
        if (GameObject.Find("Particles (Optimized)") != null)
        {
            foreach(PaintIn3D.P3dPaintSphere ph in GameObject.Find("Particles (Optimized)").GetComponents<PaintIn3D.P3dPaintSphere>())
            {
                Debug.Log(ph.Color);
                if (ph.Group == 0)
                {
                   // Debug.Log(ph.Color);
                    ph.Opacity = 0.5f;
                }
            }
        }
  */


        //foreach (PaintIn3D.P3dPaintSphere ph in transform.Find("Particles (Optimized)").GetComponents<PaintIn3D.P3dPaintSphere>())
        //Debug.Log(ph.Group.ToString());

    }

    /*
    // 給其他腳本呼叫取值
    public float GetRightHandForce()
    {
        return rightHandForce;
    }
    public float GetLeftHandForce()
    {
        return leftHandForce;
    }*/






    public Valve.VR.Extras.SteamVR_LaserPointer laserPointer;
    public SteamVR_Action_Boolean clickAction;

    private void OnEnable()
    {
        laserPointer.PointerClick += PointerClick;
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
    }

    private void OnDestroy()
    {
        laserPointer.PointerClick -= PointerClick;
        laserPointer.PointerIn -= PointerInside;
        laserPointer.PointerOut -= PointerOutside;
    }

    private void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("K_Trigger: " + e.target.gameObject.name);
        switch (e.target.gameObject.tag)
        { 
            case "Decal":
                e.target.gameObject.GetComponent<EquipDecal>().equipDecal();
                break;
            case "SprayIcon":
                e.target.gameObject.GetComponent<EnableChangeOpacity>().checkSpray();
                break;
            case "Op":
                e.target.gameObject.GetComponent<ChangeSprayOpacity>().changeOpacity();
                e.target.gameObject.GetComponent<ChangeSprayOpacity>().equipSpray();
                break;
            case "Quit":
                e.target.gameObject.GetComponent<QuitGame>().Quit();
                break;
            case "Eraser":
                e.target.gameObject.GetComponent<ChangeSprayOpacity>().equipEraser();
                break;
            case "MusicButton":
                e.target.gameObject.GetComponent<SprayMenu>().musicMenu();
                break;

            case "BGMBtn":
                e.target.gameObject.GetComponent<PlayMusic>().playMusic();
                break;
        }
            
                
        

    }

    private void PointerInside(object sender, PointerEventArgs e)
    {

        Debug.Log("K_In: " + e.target.gameObject.name);
    }

    private void PointerOutside(object sender, PointerEventArgs e)
    {

        Debug.Log("K_Out: " + e.target.gameObject.name);
    }
}
