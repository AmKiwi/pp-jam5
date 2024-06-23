using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonBaseType : ScriptableObject
{
    public int maxBullets;
    public float reloadTime;
    public float fireRate;
    public float recoil;

    public abstract void Shoot(Vector3 position, Quaternion direction);
}
