using Pokemon.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Logic.Commands
{
    public abstract class Command
    {

        public Entity Entity { get; set; }

        public abstract void Execute();
        public abstract Entity GetEntity();
        public abstract List<Entity> GetEntities();
    }
}
