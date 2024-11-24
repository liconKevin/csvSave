using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csvSave.domain.interfaces;

namespace csvSave.application
{
    public class dataManagement<T> where T : class
    {
        IdataProcess<T> _dataProcess;

        List<T> _values;

        string _filePath;

        public dataManagement(IdataProcess<T> dataProcess, string filePath)
        {
            _dataProcess = dataProcess;
            _filePath = filePath;
        }

        public void processData()
        {
            _values = _dataProcess.ProcessData(_filePath);
        }

        public void saveData()
        {
            _dataProcess.saveData(_values);
        }

    }
}
