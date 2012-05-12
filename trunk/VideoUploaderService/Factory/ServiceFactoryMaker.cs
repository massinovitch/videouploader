using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderDAO.Util;

namespace VideoUploaderService.Factory
{
    public class ServiceFactoryMaker
    {
        /**
         * Empty constructor
         */
        private ServiceFactoryMaker()
        {
            // Non intantiable contructor
        }

        /**
         * Getting the good factory
         * @param whichFactory : String
         * @return AbstractServiceFactory
         */
        public static AbstractServiceFactory getServiceFactory(String whichFactory)
        {
            AbstractServiceFactory abstractFactory = null;
            if (whichFactory.Equals(Constants.factoryPatternMySql))
                abstractFactory = ServiceFactory.getInstance();
            return abstractFactory;
        }

    }
}
