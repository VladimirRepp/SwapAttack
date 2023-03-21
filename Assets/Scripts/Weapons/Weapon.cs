using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBueyd = false;

    [SerializeField] protected Bullet Bullet;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBueyd => _isBueyd;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBueyd = true;
    }
}
