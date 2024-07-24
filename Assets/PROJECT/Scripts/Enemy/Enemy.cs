using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public int health;
    public int speed;
    public int damage;
    public int range;
   


}