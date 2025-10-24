using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor.Build;
using System;
using System.ComponentModel;

[Flags]
public enum ESkillTag
{
    //Flag를 사용함으로 비트연산을 통해 복수의 항목을 지정 가능
    None = 0,
    Near = 1 << 0,
    Physic = 1 << 1,
    Magic = 1 << 2,
}

public class CharacterStat : MonoBehaviour
{
    [Header("공통 스텟")]
    [Tooltip("캐릭터의 이름")]
    public string Name;
    [Tooltip("캐릭터의 레벨")]
    public int Level;      
    [Tooltip("캐릭터의 체력")]
    public int Health;     
    [Tooltip("캐릭터의 공격력")]
    public float Damage;  
    [Tooltip("캐릭터의 치명타율")]
    public float CritRate;   
    [Tooltip("캐릭터의 스킬발동확률")]
    public float SkillRate; 
    [Tooltip("캐릭터의 이동속도")]
    public float MoveSpeed;
    [Tooltip("캐릭터의 공격속도")]
    public float AttackSpeed;
    [Tooltip("캐릭터의 사용불가 스킬태그")]
    public ESkillTag BanSkillTag;

    [Header("해당 캐릭터 고유의 스텟")]
    public float Mana;

    

    private void Start()
    {
        Name = "Magician";
        Level = 30;
        Health = 10;
        Damage = 30.0f;
        CritRate = 0.1f;
        SkillRate = 0.23f;
        MoveSpeed = 8.3f;
        AttackSpeed = 0.69f;

        //해당 연산을 통해 Near과 Physic항목만 지정
        BanSkillTag |= ESkillTag.Near;
        BanSkillTag |= ESkillTag.Physic;

        Mana = 100;
    }
}
