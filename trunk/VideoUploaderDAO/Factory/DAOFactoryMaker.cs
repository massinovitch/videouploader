using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using VideoUploaderDAO.Util;

namespace VideoUploaderDAO.Factory
{
    public class DAOFactoryMaker
    {
        /**
         * Empty constructor
         * 
         */
        private DAOFactoryMaker()
        {
            // You are not allowed ot instantiate this class
        }

        /**
         * Getting the good factory
         * 
         * @param whichFactory
         *            the type of the factory
         * @return the good factory
         */
        public static AbstractDAOFactory getDAOFactory(String whichFactory)
        {

            AbstractDAOFactory abstractFactory = null;

            if (whichFactory.Equals(Constants.factoryPatternMySql))
            {
                abstractFactory = DAOFactory.getInstance();
            }
            return abstractFactory;

        }

    }
}
