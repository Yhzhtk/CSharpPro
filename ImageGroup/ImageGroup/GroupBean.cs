using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageGroup
{
    class GroupBean
    {
        private string groupId;

        public string GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        private string groupTitle;

        public string GroupTitle
        {
            get { return groupTitle; }
            set { groupTitle = value; }
        }

        private string groupRank;

        public string GroupRank
        {
            get { return groupRank; }
            set { groupRank = value; }
        }

        private string groupContent;

        public string GroupContent
        {
            get { return groupContent; }
            set { groupContent = value; }
        }

        private string groupKeys;

        public string GroupKeys
        {
            get { return groupKeys; }
            set { groupKeys = value; }
        }

        private string groupPath;

        public string GroupPath
        {
            get { return groupPath; }
            set { groupPath = value; }
        }

        private string groupSrcName;

        public string GroupSrcName
        {
            get { return groupSrcName; }
            set { groupSrcName = value; }
        }
    }
}
