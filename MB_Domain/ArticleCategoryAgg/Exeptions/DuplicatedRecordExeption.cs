using System;

namespace MB_Domain.ArticleCategoryAgg.Exeptions
{
    public class DuplicatedRecordExeption : Exception
    {
        public DuplicatedRecordExeption()
        {
        }

        public DuplicatedRecordExeption(string message) : base(message) { }
    }
}
