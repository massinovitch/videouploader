using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderDAO.Impl;
using VideoUploader;

namespace VideoUploaderDAO.Factory
{
    class DAOFactory : AbstractDAOFactory
    {
        private static volatile DAOFactory instance;
        private static object syncRoot = new Object();

        private DAOFactory() { }

        public static DAOFactory getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new DAOFactory();
                }
            }

            return instance;
        }

        public CommentRepository getCommentRepository()
        {
            CommentRepository commentRepository = CommentRepository.getInstance();
            return commentRepository;
        }

        public DroitGroupeRepository getDroitGroupeRepository()
        {
            DroitGroupeRepository droitGroupeRepository = DroitGroupeRepository.getInstance();
            return droitGroupeRepository;
        }

        public FolderRepository getFolderRepository()
        {
            FolderRepository folderRepository = FolderRepository.getInstance();
            return folderRepository;
        }

        public GroupeRepository getGroupeRepository()
        {
            GroupeRepository groupeRepository = GroupeRepository.getInstance();
            return groupeRepository;
        }

        public ItemRepository getItemRepository()
        {
            ItemRepository itemRepository = ItemRepository.getInstance();
            return itemRepository;
        }

        public UserRepository getUserRepository()
        {
            UserRepository userRepository = UserRepository.getInstance();
            return userRepository;
        }

    }
}
