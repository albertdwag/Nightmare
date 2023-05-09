using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : GunBaseController
{
    [SerializeField] private SOShotgunSetup _shotgunSetup;

    protected override void Shoot()
    {

        for (int i = 0; i < _shotgunSetup.numPellets; i++)
        {
            float angle = Random.Range(-_shotgunSetup.spreadAngle, _shotgunSetup.spreadAngle);
            Quaternion rotation = Quaternion.AngleAxis(angle, aim.up);
            Vector3 direction = rotation * aim.forward;

            if (Physics.Raycast(aim.position, direction, out RaycastHit hit, _shotgunSetup.range, layerMask))
            {
                var hitObject = hit.transform.GetComponent<HealthController>();
                hitObject.Damage(_shotgunSetup.damage);
                Debug.Log("Hit object: " + hit.transform.name);
            }

            _shotgunSetup.currentAmmo--;
            UpdateAmmo();
            Debug.DrawRay(aim.position, direction * _shotgunSetup.range, Color.green, 0.1f);
        }
    }
}
