using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderService.Impl;
using VideoUploaderDAO;
using VideoUploaderDAO.Util;
using VideoUploaderDAO.Factory;

namespace VideoUploaderService.Factory
{
    class ServiceFactory : AbstractServiceFactory
    {
        private static volatile ServiceFactory instance;
        private static object syncRoot = new Object();

        private ServiceFactory() { }

        public static ServiceFactory getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ServiceFactory();
                }
            }

            return instance;
        }

        public CommentRepositoryService getCommentRepositoryService()
        {
            CommentRepositoryService commentRepositoryService = CommentRepositoryService.getInstance();
            commentRepositoryService.CommentRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getCommentRepository();
            return commentRepositoryService;
        }

        public DroitGroupeRepositoryService getDroitGroupeRepositoryService()
        {
            DroitGroupeRepositoryService droitGroupeRepositoryService = DroitGroupeRepositoryService.getInstance();
            droitGroupeRepositoryService.DroitGroupeRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getDroitGroupeRepository();
            return droitGroupeRepositoryService;
        }

        public FolderRepositoryService getFolderRepositoryService()
        {
            FolderRepositoryService folderRepositoryService = FolderRepositoryService.getInstance();
            folderRepositoryService.FolderRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getFolderRepository();
            return folderRepositoryService;
        }

        public GroupeRepositoryService getGroupeRepositoryService()
        {
            GroupeRepositoryService groupeRepositoryService = GroupeRepositoryService.getInstance();
            groupeRepositoryService.GroupeRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getGroupeRepository();
            return groupeRepositoryService;
        }

        public ItemRepositoryService getItemRepositoryService()
        {
            ItemRepositoryService itemRepositoryService = ItemRepositoryService.getInstance();
            itemRepositoryService.ItemRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getItemRepository();
            return itemRepositoryService;
        }

        public UserRepositoryService getUserRepositoryService()
        {
            UserRepositoryService userRepositoryService = UserRepositoryService.getInstance();
            userRepositoryService.UserRepository = DAOFactoryMaker.getDAOFactory(Constants.factoryPatternMySql).getUserRepository();
            return userRepositoryService;
        }

    }
}
