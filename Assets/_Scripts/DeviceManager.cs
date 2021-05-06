using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    public static DeviceManager Instance;
    public Transform HMD;
    public Transform leftHand;
    public Transform rightHand;
    // Start is called before the first frame update
    void Start()
    {
        DeviceManager.Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
