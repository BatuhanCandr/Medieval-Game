using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "Player/Player", order = 2)]
public class PlayerData : ScriptableObject
{
    public int health;
    public int speed;
    public int damage;
    public float attackSpeed;
    public int range;
}