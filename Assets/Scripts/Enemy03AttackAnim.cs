using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03AttackAnim : MonoBehaviour
{
    public Collider2D enemy03attackcol;

    // Start is called before the first frame update
    void Start()
    {
        enemy03attackcol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Enemy03AttackStart()
    {
        enemy03attackcol.enabled = true;
    }

    void Enemy03AttackEnd()
    {
        enemy03attackcol.enabled = false;
    }

}
