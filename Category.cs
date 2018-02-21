
namespace Category_problem
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string Keyword { get; set; }
    }
}
