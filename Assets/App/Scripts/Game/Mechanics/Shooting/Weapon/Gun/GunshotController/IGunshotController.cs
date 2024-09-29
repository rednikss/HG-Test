using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Game.Mechanics.Shooting.Weapon.Gun.GunshotController
{
    public interface IGunshotController
    {
        public void CreateGunshot(IEnumerable<Transform> spawnPoints);
    }
}