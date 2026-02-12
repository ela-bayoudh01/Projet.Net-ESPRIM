using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore
{
    public static class CoreExtensions
    {
        public static void ShowList<T>(this IEnumerable<T> collection, string title, ShowLine showLine)
        {
            if (showLine == null) throw new ArgumentNullException(nameof(showLine));

            showLine(title);

            if (collection == null || !collection.Any())
            {
                showLine("Aucun élément dans la collection.");
                return;
            }

            foreach (var item in collection)
            {
                showLine(item?.ToString() ?? "null");
            }

            showLine("-----------------------------");
        }
    }
}
