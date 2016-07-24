using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Model
{
    class InsertVM : ModelBase
    {

        private string _Insert;
        public string Insert { get { return _Insert; } set { _Insert = value; OnPropertyChanged("Insert"); } }


    }
}
