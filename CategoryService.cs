
using System.Collections.Generic;

namespace Category_problem
{
    /// <summary>
    /// The service provide category operations  
    /// </summary>
    public class CategoryService
    {
        public List<Category> CategoryData { get; set; }

        /// <summary>
        /// Initialize with categories dataset
        /// </summary>
        /// <param name="Categories"></param>
        public CategoryService(List<Category> Categories)
        {
            CategoryData = Categories;
        }

        /// <summary>
        /// Get the categories by category level which are of N’th level in the hierarchy(categories with parentId -1 are at 1st level)
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Categories</returns>
        public List<Category> GetCategoriesByLevel(int level)
        {
            //Get categories recursively starting from root level(1)
            return (CategoryData != null) ? GetCategoriesByLevelRecursively(level, 1, -1, new List<Category>()) : null;
        }


        /// <summary>
        /// Get category data(name, parentCategoryId, key-word) by categoryId 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Category data</returns>
        public CategoryInfo GetCategoryInfoById(int categoryId)
        {
            return (CategoryData != null) ? GetCategoryInfoByIdRecursively(categoryId, null) : null;
        }

        private CategoryInfo GetCategoryInfoByIdRecursively(int categoryId, CategoryInfo categoryInfo)
        {
            foreach (var category in CategoryData)
            {
                if (category.CategoryId == categoryId)
                {
                    if (categoryInfo == null)
                    {
                        categoryInfo = new CategoryInfo()
                        {
                            Name = category.Name,
                            ParentCategoryId = category.ParentCategoryId
                        };
                    }

                    if (category.Keyword != null)
                    {
                        categoryInfo.Keyword = category.Keyword;
                        return categoryInfo;
                    }
                    else
                    {
                        GetCategoryInfoByIdRecursively(category.ParentCategoryId, categoryInfo);
                    }

                    return categoryInfo;
                }
            }

            return null;
        }

        private List<Category> GetCategoriesByLevelRecursively(int level, int current_level, int parentCategoryId, List<Category> levelCategories)
        {
            if (current_level > level)
            {
                return levelCategories;
            }

            foreach (var category in CategoryData)
            {
                if (category.ParentCategoryId == parentCategoryId)
                {
                    if (level == current_level)
                    {
                        levelCategories.Add(category);
                    }
                    else
                    {
                        GetCategoriesByLevelRecursively(level, current_level + 1, category.CategoryId, levelCategories);
                    }
                }
            }
            return levelCategories;
        }
    }
}
