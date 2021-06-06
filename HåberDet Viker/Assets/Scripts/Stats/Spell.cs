using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType
{
    SingleTargetDamage,
    AOEDamage,
    Heal,
}
[System.Serializable]
public class Spell : ScriptableObject
{
    public string SpellName, Description;
    public int Cost;
    public float CastTimer;
    public Sprite SpellIcon;
    public float SpellDamage;
    public SpellType Spelltype;
    public GameObject SpellPrefab;
}
