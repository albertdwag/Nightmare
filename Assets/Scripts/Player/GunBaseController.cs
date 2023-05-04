using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{
    [SerializeField] private SOGunSetup _gunSetup;
    [SerializeField] private UiUpdater _uiUpdater;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _gunSetup._currentAmmo != 0)
        {
            Shoot();
            _gunSetup._currentAmmo--;
            UpdateAmmo();
        }
    }

    private void Start()
    {
        _gunSetup._currentAmmo = _gunSetup._maxAmmo;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _gunSetup.range))
        {
            Debug.Log("Hit object: " + hit.transform.name);
        }
        Debug.DrawRay(transform.position, transform.forward * _gunSetup.range, Color.green, 0.1f);
    }

    private void UpdateAmmo()
    {
        if (_uiUpdater != null)
            _uiUpdater.UpdateValue(_gunSetup._currentAmmo);
    }
}
