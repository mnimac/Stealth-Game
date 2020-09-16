using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int rotateSpeed = 2;
    float speed = 2f;
    float height = 0.2f;

    Vector3 currentPos;

    void Start(){
        currentPos = transform.position;
    }

    void Update() 
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);

        //calculate what the new Y position will be
        float yAxis = Mathf.Sin(Time.time * speed) * height + currentPos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
    }
}
