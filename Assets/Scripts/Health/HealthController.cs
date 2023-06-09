using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    public UiUpdater uiUpdater;
    public Action<HealthController> OnDeath;
    public Action<HealthController> OnDamage;

    public float StartLife
    {
        get { return _startLife; }
        set { _startLife = value; }
    }

    public float CurrentLife
    {
        set { _currentLife = value; }
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

        UpdateLife();
        OnDamage?.Invoke(this);
    }

    private void Die()
    {
        OnDeath?.Invoke(this);
    }

    private void UpdateLife()
    {
        if (uiUpdater != null)
            uiUpdater.UpdateValue(_currentLife);
    }

    #region DEBUG
    [NaughtyAttributes.Button]
    private void Damage()
    {
        Damage(2);
    }
    #endregion
}
