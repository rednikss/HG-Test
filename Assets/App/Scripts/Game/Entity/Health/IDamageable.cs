﻿namespace App.Scripts.Game.Entity.Health
{
    public interface IDamageable
    {
        public void TakeDamage(float damage);

        public void Kill();
    }
}