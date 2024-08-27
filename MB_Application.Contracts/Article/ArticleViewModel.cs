using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleas Enter Title")]
        [MaxLength(255, ErrorMessage = "Long Your Text")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Pleas Enter ShortDescription")]
        [MaxLength(450,ErrorMessage = "Long Your Text")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Pleas Enter Image")]
        [MaxLength(255, ErrorMessage = "Long Your Text")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Pleas Enter Content")]
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ArticleCategoryId { get; set; }
        //public ArticleCategory ArticleCategory { get; set; }
    }
}
