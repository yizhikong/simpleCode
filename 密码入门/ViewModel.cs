using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 密码入门
{
    class ViewModel
    {
        private ObservableCollection<codes> codeList;
        private string name;
        private string introduce;
        public ViewModel()
        {
            codeList = new ObservableCollection<codes>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Introduce
        {
            get
            {
                return introduce;
            }
            set
            {
                introduce = value;
            }
        }

        public ObservableCollection<codes> CodeList
        {
            get
            {
                return codeList;
            }
        }

    }
}
