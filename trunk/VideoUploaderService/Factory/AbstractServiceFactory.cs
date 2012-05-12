using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoUploaderService.Impl;

namespace VideoUploaderService.Factory
{
    public interface AbstractServiceFactory
    {
        CommentRepositoryService getCommentRepositoryService();
        DroitGroupeRepositoryService getDroitGroupeRepositoryService();
        FolderRepositoryService getFolderRepositoryService();
        GroupeRepositoryService getGroupeRepositoryService();
        ItemRepositoryService getItemRepositoryService();
        UserRepositoryService getUserRepositoryService();
    }
}
