using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Life Settings")]
    public float life = 100f;

    [Header("Movement Settings")]
    public float playerSpeed = 2f;
}
