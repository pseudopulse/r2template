using System;

namespace ModName.Utils {
    public abstract class CoolerBasicMeleeAttack : BasicMeleeAttack {
        public abstract float BaseDuration { get; }
        public abstract float DamageCoefficient { get; }
        public abstract string HitboxName { get; }
        public abstract GameObject HitEffectPrefab { get; }
        public abstract float ProcCoefficient { get; }
        public abstract float HitPauseDuration { get; }
        public abstract GameObject SwingEffectPrefab { get; }
        public abstract string MuzzleString { get; }
        public virtual string MechanimHitboxParameter { get; }
        public virtual bool ScaleHitPauseDurationWithAttackSpeed { get; } = true;
        public override void OnEnter()
        {
            base.baseDuration = BaseDuration;
            base.damageCoefficient = DamageCoefficient;
            base.hitBoxGroupName = HitboxName;
            base.hitEffectPrefab = HitEffectPrefab;
            base.procCoefficient = ProcCoefficient;
            base.hitPauseDuration = HitPauseDuration;
            base.swingEffectPrefab = SwingEffectPrefab;
            base.swingEffectMuzzleString = MuzzleString;
            if (MechanimHitboxParameter != null) base.mecanimHitboxActiveParameter = MechanimHitboxParameter;
            base.scaleHitPauseDurationAndVelocityWithAttackSpeed = ScaleHitPauseDurationWithAttackSpeed;
            base.OnEnter();
        }
    }
}