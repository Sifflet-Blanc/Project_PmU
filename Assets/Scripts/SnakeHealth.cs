using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : CharacterHealth
{
    public Transform enemy; //l'ennemi que la barre suit
    public Vector3 offset; // D�calage entre l'ennemi et la barre.
    
    void Update()
    {
        transform.position = enemy.position + offset;    
    }
}
