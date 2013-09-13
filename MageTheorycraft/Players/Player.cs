using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft.Players
{
    public abstract class Player
    {
        abstract internal void NextSpellCast(State state);

        protected string _name;
        public string Name
        {
            get { return _name; }
        }

        internal Player(string name)
        {
            _name = name;
        }
    }
}
