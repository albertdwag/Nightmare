using System;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{
    public Transform aim;
    public LayerMask layerMask;
    public Action<GunBaseController> OnSwapWeapon;

    [SerializeField] private SOGunSetup _gunSetup;
    [SerializeField] private UiUpdater _uiUpdater;
    private string handTag = "Hand";

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _gunSetup.currentAmmo > 0 && transform.parent.CompareTag(handTag))
            Shoot();
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    private void Awake()
    {
        _gunSetup.currentAmmo = _gunSetup.maxAmmo;
        UpdateAmmo();
    }

    protected virtual void Shoot()
    {
        if (Physics.Raycast(aim.transform.position, aim.transform.forward, out RaycastHit hit, _gunSetup.range, layerMask))
        {
            var hitObject = hit.transform.GetComponent<HealthController>();
            hitObject.Damage(_gunSetup.damage);
            Debug.Log("Hit object: " + hit.transform.name);
        }

        _gunSetup.currentAmmo--;
        UpdateAmmo(); 
        Debug.DrawRay(aim.transform.position, aim.transform.forward * _gunSetup.range, Color.green, 0.1f); 
    }

    public void UpdateAmmo()
    {
        if (_uiUpdater != null)
            _uiUpdater.UpdateValue(_gunSetup.currentAmmo);
    }

    private void Reload()
    {
        _gunSetup.currentAmmo = _gunSetup.maxAmmo;
        UpdateAmmo();
    }
}
