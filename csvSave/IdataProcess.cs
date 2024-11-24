using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvSave
{
    public interface IdataProcess<T> where T : class
    {

        List<T> ProcessData(string filePath);

       
        void saveData(List<T> data);

    }
}
