using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsipLIB.Graphs
{
    public class Node
    {
        private int _id;

        public int Id => _id;
        
        public Node(int id)
        {
            if (id < 0)
                throw new Exception("Node id should be >= 0");
            
            _id = id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
