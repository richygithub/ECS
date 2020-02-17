using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LECS
{
    public static class TypeManager
    {

        private static int s_Count = 0;
        private static Dictionary<int, Type> s_ManagerdIndexToType = new Dictionary<int, Type>();
        private static Dictionary<Type, int> s_ManagerdTypeToIndex = new Dictionary<Type, int>();


        static public int GetTypeIndex(Type t)
        {
            int index;
            if( !s_ManagerdTypeToIndex.TryGetValue(t,out index))
            {
                index = ++s_Count;
                s_ManagerdTypeToIndex.Add(t, index);
            } 
            return index;

        }
/*
        static public AddType( params Type[] types)
        {

        }
        */



    }
}
