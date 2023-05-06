using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{
    [SerializeField] private SOGunSetup _gunSetup;
    [SerializeField] private UiUpdater _uiUpdater;
    public LayerMask layerMask;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _gunSetup.currentAmmo != 0)
            Shoot();
    }

    private void Awake()
    {
        _gunSetup.currentAmmo = _gunSetup.maxAmmo;
        UpdateAmmo();
    }

    public void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _gunSetup.range, layerMask))
        {
            var hitObject = hit.transform.GetComponent<HealthController>();
            hitObject.Damage(_gunSetup.damage);
            Debug.Log("Hit object: " + hit.transform.name);
        }

        _gunSetup.currentAmmo--;
        UpdateAmmo(); 
        Debug.DrawRay(transform.position, transform.forward * _gunSetup.range, Color.green, 0.1f); 
    }

    private void UpdateAmmo()
    {
        if (_uiUpdater != null)
            _uiUpdater.UpdateValue(_gunSetup.currentAmmo);
    }
}
