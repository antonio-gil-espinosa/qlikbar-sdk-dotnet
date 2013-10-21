#region

using System.Collections.Generic;
using QlikBar.SDK.DTOs;

#endregion


namespace QlikBar.SDK

{
    /// <summary>
    /// Class LinqExtensionMethods
    /// </summary>
    internal static class Enumerable
    {
        public static IEnumerable<Article> SelectManyArticles(IEnumerable<Category> collection)
        {
            foreach (var category in collection)
                foreach (Article article in category.Articles)
                    yield return article;
           
        }

        public static IEnumerable<Category> TransverseCategories(IEnumerable<Category> collection)
        {
            if (collection == null)
                yield break;

            foreach (Category item in collection)
            {
                yield return item;


                foreach (Category inner in TransverseCategories(item.Subcategories))
                    yield return inner;
            }
        }


    }
}