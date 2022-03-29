using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbervale
{
    class MoveCollection
    {
        internal static Move gyreStrike = new Move("Gyre Strike", "Summon a small gust of wind to strike the foe.", 2, 0, 0, null, false, false, false, false);
        internal static Move searingSpit = new Move("Searing Spit", "The user spits a flaming substance at the foe.", 2, 0, 0, null, false, false, false, false);
        internal static Move acidSpray = new Move("Acid Spray", "The user spits a corrosive mist at the foe.", 2, 0, 0, null, false, false, false, true);
        internal static Move poisonWave = new Move("Poison Wave", "The foe is drenched in a poison wave", 2, 0, 0, null, false, false, false, true);
        internal static Move blackout = new Move("Blackout", "User casts a veil of darkness and strikes the foe.", 6, 4, 0, null, false, false, false, false);
    }
}
