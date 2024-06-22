using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    public KeyCode up;
    public ParticleSystem trail1;
    public ParticleSystem trail2;
    public float accelerate;
    public float deccelerate;
    public float speed;
    public float turnSpeed;


    private Vector2 velocity;
    void Start () {
        tstop();
    }

    void tstart() {
        if (!trail1.isEmitting) {
            trail1.Play();
        }
        if (!trail2.isEmitting) {
            trail2.Play();
        }
    }

    void tstop() {
        if (trail1.isEmitting) {
            trail1.Stop();
        }
        if (trail2.isEmitting) {
            trail2.Stop();
        }
    }

    void Update() {
        //rotate toward mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = Vector2.Lerp(transform.up,dir,turnSpeed*Time.deltaTime);


        if (Input.GetKey(up)) {
            velocity = Vector2.Lerp(velocity,speed*transform.up,accelerate*Time.deltaTime);
        } else {
            velocity = Vector2.Lerp(velocity,Vector2.zero,deccelerate*Time.deltaTime);
        }

        if (velocity.magnitude > 0.2) {
            tstart();
        } else {
            tstop();
        }
        transform.position += (Vector3)velocity*Time.deltaTime;
    }
}
