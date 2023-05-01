using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    public Action<HealthController> OnDeath;
    public Action<HealthController> OnDamage;
    public float StartLife
    {
        get { return _startLife; }
        set { _startLife = value; }
    }

    private float _startLife;
    [SerializeField] private float _currentLife;

    private void Start()
    {
        _currentLife = _startLife;
    }

    public void Damage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
            Die();

        OnDamage?.Invoke(this);
    }
    private void Die()
    {
        OnDeath?.Invoke(this);
    }

    #region DEBUG
    [NaughtyAttributes.Button]
    private void Damage()
    {
        Damage(100);
    }
    #endregion
}
