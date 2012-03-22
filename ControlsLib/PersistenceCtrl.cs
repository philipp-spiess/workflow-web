using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenceLib;
using System.Configuration;
using System.Runtime.Remoting;

namespace ControlsLib
{
    public static class PersistenceCtrl
    {
        private static PersistenceMgr instance;

        public static PersistenceMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersistenceMgr();

                }
                return instance;
            }
        }

    }
}
