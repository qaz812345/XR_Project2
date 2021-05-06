using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// world item drops
public class ItemWorld : MonoBehaviour
{
    // public Item item;
    public GameObject x;
    public int isEraser ;
    [SerializeField]
    [Header("(second*30), 5s = 150")]
    public int remainingTime;
    Color32 color;
    void Start()
    {
        foreach (PaintIn3D.P3dPaintSphere ph in x.transform.Find("Particles (Optimized)").GetComponents<PaintIn3D.P3dPaintSphere>())
        {
            if (isEraser == 1)
            {
                //Debug.Log(ph.Color.r);
                remainingTime = 10000000;
            }
            else
                remainingTime = 2000;
        }
        
        // 30 為1秒
    }

    public GameObject GetItem()
    {
        return this.gameObject;
    }

    public void DestroySelf()
    {
        Debug.Log("destroyed");

        //Debug.Log("transform");
        x.SetActive(false);
    }
}
    
