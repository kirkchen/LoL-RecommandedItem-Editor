using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LoLRecommandItemUpdater.Model
{
    /// <summary>
    /// ItemType
    /// </summary>
    [Flags]
    public enum ItemType
    {
        None = 0,

        Health = 1,

        Armor = 2,

        HealthRegen = 4,

        MagicResist = 8,

        Damage = 16,

        CriticalStrike = 32,

        AttackSpeed = 64,

        LifeSteal = 128,

        SpellDamage = 256,

        CooldownReduction = 512,

        Mana = 1024,

        ManaRegen = 2048,

        Movement = 4096,

        Consumable = 8192,

        All = Health | Armor | HealthRegen | MagicResist | Damage | CriticalStrike | AttackSpeed | LifeSteal | SpellDamage |
              CooldownReduction | Mana | ManaRegen | Movement | Consumable,
    }
}
