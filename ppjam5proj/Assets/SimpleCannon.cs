using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleCannonType", menuName = "ScriptableObjects/SimpleCannon", order = 1)]
public class SimpleCannon : CannonBaseType
{
    public GameObject bullet;
    public override void Shoot(Vector3 position, Quaternion direction) {
        Instantiate(bullet, position, direction);
    }
}
