using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LECS
{
    unsafe public class EntityManager
    {
        public ArcheType CreateArcheType(params ComponentType[] types)
        {
            fixed( ComponentType* pType = types)
            {

                return ArcheTypeManager.GetOrCreateArcheType(pType, types.Length);
            }

        }
    }
}
