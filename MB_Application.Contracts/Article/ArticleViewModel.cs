using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MB_Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Pleas Enter Title")]
        [MaxLength(255, ErrorMessage = "Long Your Text")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Pleas Enter ShortDescription")]
        [MaxLength(450, ErrorMessage = "Long Your Text")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Pleas Enter Image")]
        [MaxLength(255, ErrorMessage = "Long Your Text")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Pleas Enter Content")]
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public int ArticleCategoryId { get; set; }
        public string ArticleCategory { get; set; }
    }
}
