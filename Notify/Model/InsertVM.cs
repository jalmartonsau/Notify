using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notify.Model
{
    class InsertVM : ModelBase
    {
        public InsertVM()
        {
            TestCommand = new DelegateCommand(Test);
        }


        private string _Insert;
        public string Insert { get { return _Insert; } set { _Insert = value; OnPropertyChanged("Insert"); } }

        public ICommand TestCommand { get; private set; }

        public void Test()
        {
            Insert = "Testikas";
        }

    }
}
