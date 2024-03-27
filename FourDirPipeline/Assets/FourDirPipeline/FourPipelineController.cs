using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPipelineController : MonoBehaviour
{
    public List<FourPipelineJointController> m_joints = new List<FourPipelineJointController>();
    public float m_horizontalValue = 0;
    public float m_verticalValue = 0;

    public void Init()
    {
       foreach(var jointCtrl in GetComponentsInChildren<FourPipelineJointController>())
        {
            m_joints.Add(jointCtrl);
            jointCtrl.m_articulationBody.enabled = true;
        }   
    }

    public void SetValue(Vector2 value)
    {
        SetHorizontalValue(value.x);
        SetVerticalValue(value.y);
    }

    public void SetHorizontalValue(float value)
    {
        m_horizontalValue = value;
    }

    public void SetVerticalValue(float value)
    {
        m_verticalValue = value;
    }

    private void Update()
    {
        foreach(var jointCtrl in m_joints)
        {
           if(jointCtrl.m_type == FourPipelineJointType.Horizonal)
            {
                jointCtrl.SetValue(m_horizontalValue);
            }
            else if(jointCtrl.m_type == FourPipelineJointType.Vertical)
            {
                jointCtrl.SetValue(m_verticalValue);
            }
        }
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 50, 50), m_horizontalValue.ToString("F2"));
        m_horizontalValue = GUI.HorizontalSlider(new Rect(80, 20, 400, 50), m_horizontalValue, -1, 1);

        GUI.Label(new Rect(20, 90, 50, 50), m_verticalValue.ToString("F2"));
        m_verticalValue = GUI.HorizontalSlider(new Rect(80, 90, 400, 50), m_verticalValue, -1, 1);
    }
}
