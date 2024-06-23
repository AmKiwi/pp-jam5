using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public CannonBaseType cannon1;
    public CannonBaseType cannon2;
    public Transform cannonpos1;
    public Transform cannonpos2;
    public moveplayer playerobj;

    private int cannon1bulletsleft;
    private float cannon1timeSinceLastFire;
    private float cannon1ReloadTimeLeft;
    private int cannon2bulletsleft;
    private float cannon2timeSinceLastFire;
    private float cannon2ReloadTimeLeft;

    public void Start() {
        cannon1bulletsleft = cannon1.maxBullets;
        cannon2bulletsleft = cannon2.maxBullets;
    }

    public void Update() {
        cannon1timeSinceLastFire -= Time.deltaTime;
        if (cannon1ReloadTimeLeft <= 0 && cannon1bulletsleft <= 0) {
            cannon1bulletsleft = cannon1.maxBullets;
        } else {
            cannon1ReloadTimeLeft -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && cannon1bulletsleft > 0 && cannon1timeSinceLastFire <= 0) {
            cannon1bulletsleft -= 1;
            cannon1timeSinceLastFire = cannon1.fireRate;
            if (cannon1bulletsleft < 1) {
                cannon1ReloadTimeLeft = cannon1.reloadTime;
            }
            cannon1.Shoot(cannonpos1.position,transform.rotation);
            playerobj.velocity -= (Vector2)(cannon1.recoil*transform.up);
        }
        //cannon2, beautiful code
        cannon2timeSinceLastFire -= Time.deltaTime;
        if (cannon2ReloadTimeLeft <= 0 && cannon2bulletsleft <= 0) {
            cannon2bulletsleft = cannon2.maxBullets;
        } else {
            cannon2ReloadTimeLeft -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(1) && cannon2bulletsleft > 0 && cannon2timeSinceLastFire <= 0) {
            cannon2bulletsleft -= 1;
            cannon2timeSinceLastFire = cannon2.fireRate;
            if (cannon2bulletsleft < 1) {
                cannon2ReloadTimeLeft = cannon2.reloadTime;
            }
            cannon2.Shoot(cannonpos2.position,transform.rotation);
            playerobj.velocity -= (Vector2)(cannon2.recoil*transform.up);
        }
    }
}
