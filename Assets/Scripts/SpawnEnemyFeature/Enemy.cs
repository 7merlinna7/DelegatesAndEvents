using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DeathType _deathType;

    public void Initialize(DeathType deathType)
    {
        _deathType = deathType;
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
