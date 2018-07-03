using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private GameObject playerReference;
    [SerializeField]
    private float smooth = 3;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if(playerReference != null)
        {
            Vector3 playerPosition = playerReference.transform.position;
            playerPosition.z = transform.position.z;
            Vector3 newPosition = Vector3.Slerp(transform.position , playerPosition,  smooth * 0.05f);
            transform.position = newPosition;
        }
    }
}
