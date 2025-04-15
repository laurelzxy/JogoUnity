
using Unity.Cinemachine;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera; 
    public bool disableMouseInput = true;

    void Start()
    {
        if (disableMouseInput)
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
}