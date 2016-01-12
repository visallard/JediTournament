using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JediTournamentEntities
{
    public abstract class EntityObject
    {
        public int ID { get; set; }

        public EntityObject() {}

        public EntityObject(int id)
        {
            ID = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            EntityObject o = (EntityObject) obj;
            return (this.ID==o.ID);
        }

        public override int GetHashCode()
        {
            return ID;
        }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
