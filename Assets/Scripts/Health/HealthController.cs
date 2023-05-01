using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    private float _startLife = 100f;
    [SerializeField] private float _currentLife;
    public Action<HealthController> OnDeath;

    private void Awake()
    {
        _currentLife = _startLife;
    }
    public void Damage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
            Die();
    }
    private void Die()
    {
        OnDeath?.Invoke(this);
    }
}
