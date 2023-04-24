using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notification
{
    internal class Post
    {

        //  ID
        public Guid ID { get; init; }

        //  Creation date
        public DateTime CreationTime { get; init; }

        //  Content
        public string Content { get; set; }

        //  Count of like
        private int _likeCount = 0;
        public int LikeCount { get { return _likeCount; } }

        //  Count of view
        private int _viewCount = 0;
        public int ViewCount { get { return _viewCount; } }

        //  Constructor with parametres
        public Post(Guid iD,string content,DateTime creationTime)
        {
            ID = iD;
            Content = content;
            CreationTime = creationTime;
        }

        //  For show on console
        public override string ToString()
        {
            return $"Content: {Content}\nID: {ID}\nCreation time: {CreationTime}\nCount of likes: {LikeCount}\nCount of views: {ViewCount}";
        }

        //  Increement of count of likes
        public void IncreementLikeCount()
        {
            _likeCount++;
        }

        //  Increement of count of views
        public void IncreementViewCount()
        {
            _viewCount++;
        }

    }
}
