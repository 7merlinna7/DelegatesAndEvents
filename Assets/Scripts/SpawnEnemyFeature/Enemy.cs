using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isDead;

    public bool IsDead => _isDead;

    

    public void Kill(float destroyTime = 0)
    {
        Destroy(gameObject);
    }
}
