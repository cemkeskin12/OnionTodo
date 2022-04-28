using OT.Domain.Common;

namespace OT.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
    }
}
