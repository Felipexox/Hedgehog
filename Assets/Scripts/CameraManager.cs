using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private GameObject playerReference;
    public static CameraManager instance;
    [SerializeField]
    private float smooth = 3;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
      
    }
    public void Update()
    {
        if (playerReference != null)
        {
            virtualCamera.Follow = playerReference.transform;
        }
    }
}
