using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPullToRefresh
{
    class OrderInfoRepository : NotificationObject
    {

        private ObservableCollection<OrderInfo> orderInfo;
        private int _pageSize;

        private int count = 1045;

        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { this._pageSize = value; }
        }
        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            PageSize = 20;
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            for (int i = 1; i <= 5; i++)
            {
                orderInfo.Add(new OrderInfo(1001, "Maria Anders", "Mexico", "ANATR", "Mexico D.F.", true));
                orderInfo.Add(new OrderInfo(1002, "Ana Trujillo", "Mexico", "ANTON", "Mexico D.F.", true));
                orderInfo.Add(new OrderInfo(1003, "Ant Fuller", "UK", "AROUT", "London", true));
                orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "Sweden", "BERGS", "Berlin", true));
                orderInfo.Add(new OrderInfo(1005, "Lenny Lin", "Germany", "BLAUS", "Mannheim", true));
                orderInfo.Add(new OrderInfo(1006, "John Carter", "France", "BLONP", "Strasbourg", true));
                orderInfo.Add(new OrderInfo(1007, "Laura King", "Spain", "BOLID", "Madrid", true));
                orderInfo.Add(new OrderInfo(1008, "Hanna Moos", "France", "BONAP", "Marseille", false));
                orderInfo.Add(new OrderInfo(1009, "Lenny Lin", "Canada", "BOTTM", "Tsawassen", false));
                orderInfo.Add(new OrderInfo(1010, "Hanna Moos", "UK", "AROUT", "London", false));
                orderInfo.Add(new OrderInfo(1011, "John Carter", "Germany", "BLAUS", "Mannheim", false));
                orderInfo.Add(new OrderInfo(1012, "Tim Adams", "France", "BLONP", "Strasbourg", true));
                orderInfo.Add(new OrderInfo(1013, "Hanna Moos", "UK", "AROUT", "London", false));
                orderInfo.Add(new OrderInfo(1014, "John Carter", "Germany", "ALFKI", "Berlin", true));
                orderInfo.Add(new OrderInfo(1015, "Hanna Moos", "Mexico", "ANATR", "Mexico D.F.", false));
                orderInfo.Add(new OrderInfo(1016, "Laura King", "Mexico", "ANTON", "Mexico D.F.", false));
                orderInfo.Add(new OrderInfo(1017, "Lenny Lin", "UK", "AROUT", "London", false));
                orderInfo.Add(new OrderInfo(1018, "Thomas Hardy", "Sweden", "BERGS", "Berlin", true));
                orderInfo.Add(new OrderInfo(1019, "Lenny Lin", "Germany", "BLAUS", "Mannheim", true));
                orderInfo.Add(new OrderInfo(1020, "Gina Irene", "France", "BLONP", "Strasbourg", true));
                orderInfo.Add(new OrderInfo(1021, "Laura King", "Spain", "BOLID", "Madrid", false));
                orderInfo.Add(new OrderInfo(1022, "Anne Wilson", "France", "BONAP", "Marseille", true));
                orderInfo.Add(new OrderInfo(1023, "Lenny Lin", "Canada", "BOTTM", "Tsawassen", false));
                orderInfo.Add(new OrderInfo(1024, "Gina Irene", "UK", "AROUT", "London", true));
                orderInfo.Add(new OrderInfo(1025, "Thomas Hardy", "Germany", "BLAUS", "Mannheim", true));
                orderInfo.Add(new OrderInfo(1026, "Anne Wilson", "France", "BLONP", "Strasbourg", false));
                orderInfo.Add(new OrderInfo(1027, "Laura King", "UK", "AROUT", "London", true));
                orderInfo.Add(new OrderInfo(1028, "Anne Wilson", "France", "BLONP", "Strasbourg", true));
                orderInfo.Add(new OrderInfo(1029, "Gina Irene", "UK", "AROUT", "London", false));
                orderInfo.Add(new OrderInfo(1030, "Anne Wilson", "Germany", "ALFKI", "Berlin", false));
                orderInfo.Add(new OrderInfo(1031, "Tim Adams", "Mexico", "ANATR", "Mexico D.F.", true));
                orderInfo.Add(new OrderInfo(1032, "Anne Wilson", "Mexico", "ANTON", "Mexico D.F.", true));
                orderInfo.Add(new OrderInfo(1033, "Gina Irene", "UK", "AROUT", "London", false));
                orderInfo.Add(new OrderInfo(1034, "Ant Fuller", "Sweden", "BERGS", "Berlin", true));
                orderInfo.Add(new OrderInfo(1035, "Thomas Hardy", "Germany", "BLAUS", "Mannheim", false));
                orderInfo.Add(new OrderInfo(1036, "Gina Irene", "France", "BLONP", "Strasbourg", true));
                orderInfo.Add(new OrderInfo(1037, "Hanna Moos", "Spain", "BOLID", "Madrid", false));
                orderInfo.Add(new OrderInfo(1038, "Anne Wilson", "France", "BONAP", "Marseille", false));
                orderInfo.Add(new OrderInfo(1039, "Thomas Hardy", "Canada", "BOTTM", "Tsawassen", true));
                orderInfo.Add(new OrderInfo(1040, "Tim Adams", "UK", "AROUT", "London", true));
                orderInfo.Add(new OrderInfo(1041, "Anne Wilson", "Germany", "BLAUS", "Mannheim", true));
                orderInfo.Add(new OrderInfo(1042, "Thomas Hardy", "France", "BLONP", "Strasbourg", false));
                orderInfo.Add(new OrderInfo(1043, "Hanna Moos", "UK", "AROUT", "London", true));
                orderInfo.Add(new OrderInfo(1044, "John Carter", "Germany", "ALFKI", "Berlin", false));
            }
        }

        public void ItemsSourceRefresh()
        {
            orderInfo.Insert(0, new OrderInfo(1101, "Maria Anders", "Mexico", "ANATR", "Mexico D.F.", true));
            orderInfo.Insert(1, new OrderInfo(1102, "Ana Trujillo", "Mexico", "ANTON", "Mexico D.F.", true));
            orderInfo.Insert(2, new OrderInfo(1103, "Ant Fuller", "UK", "AROUT", "London", true));
            orderInfo.Insert(3, new OrderInfo(1104, "Thomas Hardy", "Sweden", "BERGS", "Berlin", true));
            orderInfo.Insert(4, new OrderInfo(1105, "Lenny Lin", "Germany", "BLAUS", "Mannheim", true));
        }
    }

    public class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
