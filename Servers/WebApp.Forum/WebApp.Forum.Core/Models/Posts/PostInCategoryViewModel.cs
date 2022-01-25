namespace WebApp.Forum.Models.Posts
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    public class PostInCategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public int CommentsCount { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(Content, @"<[^>]+>", string.Empty));
                return content.Length > 300
                        ? content.Substring(0, 300) + "..."
                        : content;
            }
        }
    }
}
