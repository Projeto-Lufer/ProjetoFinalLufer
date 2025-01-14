using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthPoints : HealthPoints
{
    [SerializeField] private EnemyHealthPointsView HPView;
    [SerializeField] private StateMachine stateMachine;

    [Header("Audio FMOD Event")]
    [FMODUnity.EventRef]
    public string sfxEnemyGrowlReceivingDamage;
    [FMODUnity.EventRef]
    public string sfxEnemyHitReceivingDamage;
    [FMODUnity.EventRef]
    public string sfxEnemyDying;

    public override void ReduceHealth(ComboElement attackStats)
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxEnemyHitReceivingDamage, transform.position);
        FMODUnity.RuntimeManager.PlayOneShot(sfxEnemyGrowlReceivingDamage, transform.position);
        base.ReduceHealth(attackStats);

        HPView.PlayDamageVisuals();

        stateMachine.ChangeState (typeof(FlinchingState), attackStats.hitstunDuration);

        if (base.curHP <= 0)
        {
            Die();
        }
    }

    public void Stun()
    {
        HPView.SetStunnedVFXEnabled(true);
        stateMachine.ChangeState(typeof(StunnedState));
    }

    private void Die()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sfxEnemyGrowlReceivingDamage, transform.position);
        FMODUnity.RuntimeManager.PlayOneShot(sfxEnemyDying, transform.position);
        HPView.PlayDeathVisual();
        Destroy(parentToDestroy);
    }
}
