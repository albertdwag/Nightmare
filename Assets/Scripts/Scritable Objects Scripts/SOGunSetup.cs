using UnityEngine;

[CreateAssetMenu]
public class SOGunSetup : ScriptableObject
{
    public float range = 100f;
    public float damage = 10f;
    public int maxAmmo = 7;
    public int currentAmmo;
}
