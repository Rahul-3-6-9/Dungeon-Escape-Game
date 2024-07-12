using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.3f;
    public float y_position;
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, 203.6f, -35.4f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
