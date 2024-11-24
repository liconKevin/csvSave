using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvSave
{
    public class dataManagement<T> where T : class
    {
        IdataProcess<T> _dataProcess;

        List<T> _values;

        string _filePath;

        public dataManagement(IdataProcess<T> dataProcess, string filePath)
        {
            this._dataProcess = dataProcess;
            _filePath = filePath;
        }

        public void processData()
        {
            _values = _dataProcess.ProcessData(this._filePath);
        }

        public void saveData()
        {
            this._dataProcess.saveData(this._values);
        }

    }
}
