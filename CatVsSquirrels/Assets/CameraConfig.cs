using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
[RequireComponent(typeof(CinemachineVirtualCamera))]
[ExecuteAlways]
public class CameraConfig : MonoBehaviour
{
    [SerializeField] private int OrthoSize = 10;
    
    private CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<CinemachineVirtualCamera>();
        camera.m_Lens.OrthographicSize = OrthoSize;
    }

    private void OnValidate()
    {
        camera = this.GetComponent<CinemachineVirtualCamera>();
        camera.m_Lens.OrthographicSize = OrthoSize;
    }
}
