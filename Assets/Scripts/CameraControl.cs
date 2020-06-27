using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] Vector3 offset;
    [SerializeField] float feedbackLoopFactor = 0.1f;
    public GameObject player;
    Vector2 playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = followTarget.position + offset;
        targetPosition.z = transform.position.z;

        Vector3 delta = targetPosition - transform.position;

        transform.position = transform.position + delta * feedbackLoopFactor;
    }
}
