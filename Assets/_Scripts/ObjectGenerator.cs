using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PaintIn3D;

public class ObjectGenerator : MonoBehaviour { 
    public int n_objects = 5;
    public float height = 1.5f;
    public float x_range = 4;
    public float z_range = 4;
    public GameObject hvlpPrefab;

    private void Awake()
    {
        
        for (int i = 0; i < n_objects; i++)
        {
            Vector3 position = new Vector3(Random.Range(-x_range, x_range), height, Random.Range(-z_range, z_range));
            //PhotonNetwork.Instantiate("Cube", position, Quaternion.identity, 0);
            GameObject tempObject = GameObject.Instantiate(hvlpPrefab, position, Quaternion.identity);
            Color randColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //tempObject.GetPhotonView().ViewID = 10 + i;
            setHVLPColor(tempObject, randColor);//, randColor
        }
       

    }

    /*void setHVLPColor(GameObject hvlp, Color randColor)
    {
        HVLPSetting hvlpSetting = hvlp.GetComponent<HVLPSetting>();
        hvlpSetting.setHVLPColor(randColor);
    }*/

    // set hvlp color
    void setHVLPColor(GameObject hvlpObject, Color color)
    {
        // get HVLP game object
        Renderer hvplRenderer = hvlpObject.GetComponent<Renderer>();
        hvplRenderer.material.color = color;

        // get Particles game object
        GameObject hvlpParticles = hvlpObject.transform.GetChild(0).gameObject;

        // get ParticleSystem component
        ParticleSystem.MainModule hvplPSMain = hvlpParticles.GetComponent<ParticleSystem>().main;
        hvplPSMain.startColor = color;

        // set color of Paint
        hvlpParticles.GetComponent<P3dPaintSphere>().Color = color;
    }
}
