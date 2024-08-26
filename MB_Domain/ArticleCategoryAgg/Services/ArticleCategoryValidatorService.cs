using MB_Domain.ArticleCategoryAgg.Exeptions;
using System;

namespace MB_Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckExist(string title)
        {
            if (_articleCategoryRepository.CheckExist(title))
            {
                throw new DuplicatedRecordExeption("this record is ready exist in database");
            }
        }
    }
}
