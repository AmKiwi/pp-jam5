using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletfunctions : MonoBehaviour
{
    public float speed;
    public float lifespan;
    private float timeAlive;
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > lifespan) {
            Destroy(this.gameObject);
        }
        transform.position += transform.up*speed*Time.deltaTime;
    }
}
