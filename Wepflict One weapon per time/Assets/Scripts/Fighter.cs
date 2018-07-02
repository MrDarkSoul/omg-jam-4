using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour {

    public int maxHealth;
    public int Health { get; private set; }
    
    private Weapon defaultWeapon;

    private Weapon equippedWeapon;

    public delegate void WeaponHandler(Fighter p, Weapon w);
    public event WeaponHandler HasEquippedWeapon;
    public event WeaponHandler HasUnequippedWeapon;

    public delegate void HealthHandler(Fighter p, int s);
    public event HealthHandler HasTakenDamage;
    public event HealthHandler HasRecoveredHealth;

    public delegate void DeathHandler(Player p);
    public event DeathHandler HasDied;

    private void Awake()
    {
        defaultWeapon = Toolbox.Instance.DefaultWeapon;
    }

    public void EquipWeapon(Weapon w)
    {
        equippedWeapon = w;

        if (HasEquippedWeapon != null)
        {
            HasEquippedWeapon(this, w);
        }
    }

    public void UnequipWeapon()
    {
        Weapon w = equippedWeapon;
        EquipWeapon(defaultWeapon);

        if (HasUnequippedWeapon != null)
        {
            HasUnequippedWeapon(this, w);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (HasTakenDamage != null)
        {
            HasTakenDamage(this, Health);
        }

        if (Health == 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        
    }

    public abstract void Die();
}
