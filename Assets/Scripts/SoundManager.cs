using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Player Sounds")]
    public static AudioClip DamagePlayerSound, WalkingSound, HealthSound; 
    [Header("Fire Weapon Sounds")]
    public static AudioClip FireSound, EmptyMagSound;
    [Header("Grenade Sounds")]
    public static AudioClip GrenadeTossSound, GrenadeExplosionSound;
    [Header("Knife Weapon Sounds")]
    public static AudioClip FPunchSound, SPunchSound, TPunchSound;
    [Header("Enemy Sounds")]
    public static AudioClip EnemyDeathSound, EnemyDeathSound2;
    [Header("Elevator Sounds")]
    public static AudioClip ElevatorOnSound, ElevatorOffSound;

    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        //Player Sounds
        DamagePlayerSound = Resources.Load<AudioClip> ("damagePlayer");
        WalkingSound = Resources.Load<AudioClip> ("walk");
        HealthSound = Resources.Load<AudioClip> ("health");
        //Fire Weapon Sounds
        FireSound = Resources.Load<AudioClip> ("OneBulletFire");
        EmptyMagSound = Resources.Load<AudioClip> ("emptyMag");
        //Grenade Sounds
        GrenadeTossSound = Resources.Load<AudioClip> ("nadeToss");
        GrenadeExplosionSound = Resources.Load<AudioClip> ("nadeExplosion");
        //Knife Sounds 
        FPunchSound = Resources.Load<AudioClip> ("firstPunch");
        SPunchSound = Resources.Load<AudioClip> ("secondPunch");
        TPunchSound = Resources.Load<AudioClip> ("thirdPunch");
        //Enemy Sounds
        EnemyDeathSound = Resources.Load<AudioClip> ("deathCombatForm");
        EnemyDeathSound2 = Resources.Load<AudioClip> ("deathCombatForm2");
        //Elevator Sounds
        ElevatorOnSound = Resources.Load<AudioClip> ("elevatorOn");
        ElevatorOffSound = Resources.Load<AudioClip> ("elevatorOff");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
        //Player Sounds Call
        case "damagePlayer":
            audioSrc.PlayOneShot (DamagePlayerSound);
            break;
        case "walk":
            audioSrc.PlayOneShot (WalkingSound);
            break;
        case "health":
            audioSrc.PlayOneShot (HealthSound);
            break;
        //Fire Weapon Sounds Call
        case "OneBulletFire":
            audioSrc.PlayOneShot (FireSound);
            break;
        case "emptyMag":
            audioSrc.PlayOneShot (EmptyMagSound);
            break;
        //Grenade Sounds Call
        case "nadeToss":
            audioSrc.PlayOneShot (GrenadeTossSound);
            break;
        case "nadeExplosion":
            audioSrc.PlayOneShot (GrenadeExplosionSound);
            break;
        //Knife Sounds Call
        case "firstPunch":
            audioSrc.PlayOneShot (FPunchSound);
            break;
        case "secondPunch":
            audioSrc.PlayOneShot (SPunchSound);
            break;
        case "thirdPunch":
            audioSrc.PlayOneShot (TPunchSound);
            break;
        //Enemy Sounds Call
        case "deathCombatForm":
            audioSrc.PlayOneShot (EnemyDeathSound);
            break;
        case "deathCombatForm2":
            audioSrc.PlayOneShot (EnemyDeathSound2);
            break;
        case "elevatorOn":
            audioSrc.PlayOneShot (ElevatorOnSound);
            break;
        case "elevatorOff":
            audioSrc.PlayOneShot (ElevatorOffSound);
            break;
        }
    }
}
