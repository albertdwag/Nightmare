using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseController : MonoBehaviour
{
    public float range = 100f;

    private int _maxAmmo = 7;
    [SerializeField] private int _currentAmmo;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log("Hit object: " + hit.transform.name);
        }
        Debug.DrawRay(transform.position, transform.forward * range, Color.green, 0.1f);
    }
}
