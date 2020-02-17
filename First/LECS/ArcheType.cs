using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LECS
{
    public struct ArcheType
    {

    }

    public unsafe static class ArcheTypeManager
    {




        public static int GetHashCode(ComponentType* types, int count)
        {

            return 0;
        }

        public static ArcheType GetOrCreateArcheType(ComponentType* types,int count)
        {

            return new ArcheType();
        }


    }


}
