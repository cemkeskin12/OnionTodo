using OT.Domain.Common;

namespace OT.Domain.Entities
{
    public class Article : BaseEntity
    {
        public Article()
        {

        }
        public Article(string title, string content, string note)
        {
            SetTitle(title);
            SetContent(content);
            SetNote(note);
            CreatedDate = DateTime.Now;
        }

        public void SetNote(string note)
        {
            if (string.IsNullOrEmpty(note))
                throw new Exception("Boş geçilemez");
            Note = note;
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new Exception("Boş geçilemez");
            Content = content;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Boş geçilemez");
            Title = title;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
    }
}
