using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWarWSB
{
    public interface ICombatant
    {
        int HealthPoints { get; }
        int Damage { get; }

        void TakeDamage(int damage);
    }
}
