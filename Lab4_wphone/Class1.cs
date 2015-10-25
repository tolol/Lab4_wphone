using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;



namespace Lab4_wphone
{
    //public struct MyElement
    //{
    //    public string Element;
    //    public bool Active;
    //    public float Money;
    //}

    //public static class MyDatabase
    //{
    //    public static List<MyElement> Values;

    //    public static void Init()
    //    {
    //        Values = new List<MyElement>();

    //        MyElement tmp;
    //        tmp.Element = "зарплата";
    //        tmp.Active = true;
    //        tmp.Money = 15000f;
    //        Values.Add(tmp);

    //        tmp.Element = "донор крови";
    //        tmp.Active = true;
    //        tmp.Money = 2000f;
    //        Values.Add(tmp);

    //        tmp.Element = "ресторан";
    //        tmp.Active = false;
    //        tmp.Money = 3500f;
    //        Values.Add(tmp);
    //    }

    //}

    public class CostsDataContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/Costs.sdf";

        // Pass the connection string to the base class.
        public CostsDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a single table for the to-do items.
        public Table<Cost> Costs;
    }


    [Table]
    public class Cost : INotifyPropertyChanged, INotifyPropertyChanging
    {
        // Define ID: private field, public property and database column.
        private int _CostId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity",
        CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int CostId
        {
            get
            {
                return _CostId;
            }
            set
            {
                if (_CostId != value)
                {
                    NotifyPropertyChanging("CostId");
                    _CostId = value;
                    NotifyPropertyChanged("CostId");
                }
            }
        }

        // Define item name: private field, public property and database column.
        private string _Name;

        [Column]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    NotifyPropertyChanging("Name");
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        // Define completion value: private field, public property and database column.
        private bool _IsActive;

        [Column]
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                if (_IsActive != value)
                {
                    NotifyPropertyChanging("IsActive");
                    _IsActive = value;
                    NotifyPropertyChanged("IsActive");
                }
            }
        }

        // Define completion value: private field, public property and database column.
        private float _Money;

        [Column]
        public float Money
        {
            get
            {
                return _Money;
            }
            set
            {
                if (_Money != value)
                {
                    NotifyPropertyChanging("Money");
                    _Money = value;
                    NotifyPropertyChanged("Money");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

}
