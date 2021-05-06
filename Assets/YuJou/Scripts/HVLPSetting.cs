using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PaintIn3D;

public class HVLPSetting : MonoBehaviour
{

    public void setHVLPColor(Color color)
    {
        GetComponent<PhotonView>().RPC("_setHVLPColor", RpcTarget.All, new Vector3(color.r, color.g, color.b));
    }

    [PunRPC]
    public void _setHVLPColor(Vector3 color)
    {
        Color randColor = new Color(color.x, color.y, color.z);
        // get HVLP game object
        Renderer hvplRenderer = GetComponent<Renderer>();
        hvplRenderer.material.color = randColor;

        // get Particles game object
        GameObject hvlpParticles = this.transform.GetChild(0).gameObject;

        // get ParticleSystem component
        ParticleSystem.MainModule hvplPSMain = hvlpParticles.GetComponent<ParticleSystem>().main;
        hvplPSMain.startColor = randColor;

        // set color of Paint
        hvlpParticles.GetComponent<P3dPaintSphere>().Color = randColor;
    }
}
