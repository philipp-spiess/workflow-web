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
        private static IPersistenceMgr instance;

        public static IPersistenceMgr Instance
        {
            get
            {
                if (instance == null)
                {
                    /**
                     * Reflection
                     **/

                    AppSettingsReader config = new AppSettingsReader();

                    String persistence_mgr = (String)config.GetValue("PersistenceMgr", typeof(String));
                    String home_path = (String)config.GetValue("HomePath", typeof(String));

                    ObjectHandle h = Activator.CreateInstanceFrom(
                        home_path + persistence_mgr + @"\bin\Debug\" + persistence_mgr + @".dll",
                        persistence_mgr + @".GetInstance"
                    );
                    IGetInstence instence_getter = (IGetInstence)h.Unwrap();

                    instance = instence_getter.Instence();

                }
                return instance;
            }
        }

    }
}
