using System.Collections.Generic;

namespace Common
{
    public interface ITreeTraversal<T>
    {        
        IEnumerable<T> GetItems(TreeTraversal treeTraversal);
    }
}
