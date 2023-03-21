using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HeadlthChenged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        ChengedWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    private void OnEnemyDeid(int reward)
    {
        Money += reward;
    }

    public void ApllyDamage(int damage)
    {
        _currentHealth -= damage;
        HeadlthChenged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        ChengedWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;

        ChengedWeapon(_weapons[_currentWeaponIndex]);
    }

    public void ChengedWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
