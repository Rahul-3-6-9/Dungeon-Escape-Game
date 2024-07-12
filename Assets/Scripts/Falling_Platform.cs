using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    public float Destroytime=1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("destroy", Destroytime);
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
