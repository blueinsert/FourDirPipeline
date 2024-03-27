using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FourPipelineJointType
{
    None = 0,
    Horizonal,
    Vertical,
}

public class FourPipelineJointController : MonoBehaviour
{
    public GameObject m_linkHNode;
    public GameObject m_linkVNode;
    public ArticulationBody m_articulationBody;
    public Vector2 m_rotateLimit = new Vector2(-15, 15);

    public FourPipelineJointType m_type;
    public void SetLinkType(FourPipelineJointType type)
    {
        m_type = type;
        m_linkHNode.SetActive(m_type == FourPipelineJointType.Horizonal);
        m_linkVNode.SetActive(m_type == FourPipelineJointType.Vertical);
        SetArticulationBody();
    }

    public void HideLinks()
    {
        m_linkHNode.SetActive(false);
        m_linkVNode.SetActive(false);
    }

    private void SetArticulationBody()
    {
        var ro = Quaternion.Euler(0, m_type == FourPipelineJointType.Horizonal ? 0 : 90, 0);
        m_articulationBody.anchorRotation = ro;
    }

    public void SetRotateLimit(float max)
    {
        m_rotateLimit = new Vector2(-max, max);
    }

    public void SetValue(float value)
    {
        var temp = m_articulationBody.xDrive;
        value = (value + 1.0f) / 2;
        value = Mathf.Clamp01(value);
        temp.target = Mathf.Lerp(m_rotateLimit.x, m_rotateLimit.y, value);
        m_articulationBody.xDrive = temp;
    }
    
}
