using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LECS
{
    public struct ComponentType
    {
        private int typeIndex;


        public ComponentType(Type t)
        {
            typeIndex = TypeManager.GetTypeIndex(t);
        }

        public static implicit  operator ComponentType(Type t)
        {
            return new ComponentType(t);
        }



    }
}
