using System.ComponentModel.DataAnnotations;

namespace MB_Application.ArticleCategoryAgg
{
    public class ArticleCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "not Empty Field")]
        [MaxLength(255)]
        public string Title { get; set; }
        public string CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
