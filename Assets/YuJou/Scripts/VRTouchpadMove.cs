using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRTouchpadMove : MonoBehaviour
{
    public float m_Seneitivity = 0.5f;
    public float m_MaxSpeed = 2.5f;
    private float m_Speed = 0.0f;
    public SteamVR_Action_Boolean m_MovePress ;
    public SteamVR_Action_Vector2 m_MoveValue  ;
    public Transform m_CameraRig  ;
    public Transform m_Head  ;


    private void Update()
    {
        HandleHead();
        CalculateMovement();

    }

    private void HandleHead()
    {
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }

    private void CalculateMovement()
    {
        Vector3 movement = Vector3.zero;

        if (m_MovePress.GetLastStateUp(SteamVR_Input_Sources.Any))
            m_Speed = 0;

        if (m_MovePress.state)
        {
            m_Speed += Mathf.Abs(m_MoveValue.axis.y) * m_Seneitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);
            //Debug.Log("Touchpad Value: " + "( " + m_MoveValue.axis.x + ", " + m_MoveValue.axis.y + ")");
            movement += m_Speed * (transform.right * m_MoveValue.axis.x + transform.forward * m_MoveValue.axis.y) * Time.deltaTime;
            //Debug.Log("Movement: "  + "(" + movement.x + ", " + movement.y + ", " + movement.z + ")");
            m_CameraRig.position += movement;
            m_CameraRig.position = new Vector3(m_CameraRig.position.x, 0, m_CameraRig.position.z);
        }
    }
}
