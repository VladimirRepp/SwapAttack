using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _spread;

    public override void Shoot(Transform shootPoint)
    {
        Vector3[] points = new Vector3[3];
        points[0] = new Vector3(shootPoint.position.x, shootPoint.position.y - _spread, 0);
        points[1] = shootPoint.position;
        points[2] = new Vector3(shootPoint.position.x, shootPoint.position.y + _spread, 0);

        Instantiate(Bullet, points[0], Quaternion.identity);
        Instantiate(Bullet, points[1], Quaternion.identity);
        Instantiate(Bullet, points[2], Quaternion.identity);
    }
}
