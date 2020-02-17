using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LECS
{
    public class World:IDisposable
    {
        static World _defaultWorld;
        static public World DefaultWorld()
        {
            if (_defaultWorld == null)
            {
                _defaultWorld = new World();
            }
            return _defaultWorld;
        }

        public void Dispose()
        {
            int i = 0;
        }

        public World()
        {
            _entityManager = new EntityManager();
        }

        //entity
        EntityManager _entityManager;

        public EntityManager entityManager
        {
            get { return _entityManager; }
        }

    }
}
