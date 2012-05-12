using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderDAO.Impl;
using VideoUploader;

namespace VideoUploaderDAO.Factory
{
    public interface AbstractDAOFactory
    {
        CommentRepository getCommentRepository();
        DroitGroupeRepository getDroitGroupeRepository();
        FolderRepository getFolderRepository();
        GroupeRepository getGroupeRepository();
        ItemRepository getItemRepository();
        UserRepository getUserRepository();
    }
}
