using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PaintIn3D;

[RequireComponent(typeof(PhotonView))]
public class TextureSync : MonoBehaviour
{
    private P3dPaintableTexture texture;

    private void Awake()
    {
        
        texture = GetComponent<P3dPaintableTexture>();
    }
    
     void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            byte[] textureBytes = P3dHelper.LoadBytes(texture.SaveName);
            GetComponent<PhotonView>().RPC("setTexture", RpcTarget.AllBuffered, textureBytes);
        }
    }

    [PunRPC]
    void setTexture(byte[] textureBytes)
    {
        P3dHelper.SaveBytes(texture.SaveName, textureBytes);
    }
    /*public class PhotonRigidbodyView : MonoBehaviour, IPunObservable
    {
        [SerializeField]
        bool m_SynchronizeVelocity = true;

        [SerializeField]
        bool m_SynchronizeAngularVelocity = true;

        Rigidbody m_Body;

        void Awake()
        {
            this.m_Body = GetComponent<Rigidbody>();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {


            if (stream.isWriting == true)
            {
                if (this.m_SynchronizeVelocity == true)
                {
                    stream.SendNext(this.m_Body.velocity);
                }

                if (this.m_SynchronizeAngularVelocity == true)
                {
                    stream.SendNext(this.m_Body.angularVelocity);

                }
            }
            else
            {
                if (this.m_SynchronizeVelocity == true)
                {
                    this.m_Body.velocity = (Vector3)stream.ReceiveNext();
                }

                if (this.m_SynchronizeAngularVelocity == true)
                {
                    this.m_Body.angularVelocity = (Vector3)stream.ReceiveNext();
                }
            }
        }
    }*/
}
