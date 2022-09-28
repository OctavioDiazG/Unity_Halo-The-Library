using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloorMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float YOffset = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y - YOffset,0f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
