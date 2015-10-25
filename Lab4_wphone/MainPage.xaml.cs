using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lab4_wphone.Resources;
using System.ComponentModel;
using System.Collections.ObjectModel;



namespace Lab4_wphone
{



    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {

        private CostsDataContext CostsDB;

        private ObservableCollection<Cost> _Costs;
        public ObservableCollection<Cost> Costs
        {
            get
            {
                return _Costs;
            }
            set
            {
                if (_Costs != value)
                {
                    _Costs = value;
                    NotifyPropertyChanged("Costs");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        //private void DrawList()
        //{
        //    lstElements.Items.Clear();

        //    for (int i = 0; i < MyDatabase.Values.Count; i++)
        //    {
        //        ListBoxItem lstitNew = new ListBoxItem();
        //        StackPanel spNew = new StackPanel();
        //        TextBlock tbElem = new TextBlock();
        //        TextBlock tbAP = new TextBlock();
        //        TextBlock tbMoney = new TextBlock();

        //        tbElem.Text = MyDatabase.Values[i].Element;
        //        tbElem.FontSize = 28;
        //        tbElem.Width = 300;

        //        tbAP.Text = MyDatabase.Values[i].Active ? "А" : "П";
        //        tbAP.FontSize = 28;
        //        tbAP.Width = 50;
        //        tbAP.TextAlignment = TextAlignment.Center;

        //        tbMoney.Text = MyDatabase.Values[i].Money.ToString();
        //        tbMoney.FontSize = 28;
        //        tbMoney.Width = 100;
        //        tbMoney.TextAlignment = TextAlignment.Right;

        //        spNew.Orientation = System.Windows.Controls.Orientation.Horizontal;
        //        spNew.Margin = new Thickness(0, 10, 0, 10);
        //        spNew.Children.Add(tbElem);
        //        spNew.Children.Add(tbAP);
        //        spNew.Children.Add(tbMoney);

        //        lstitNew.Content = spNew;

        //        lstElements.Items.Add(lstitNew);
        //    }
        //}



        // Вызывается при переходе на текущую страницу
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var CostsInDB = from Cost cost in CostsDB.Costs
                            select cost;

            Costs = new ObservableCollection<Cost>(CostsInDB);

            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("name") &&
                NavigationContext.QueryString.ContainsKey("isactive") &&
                NavigationContext.QueryString.ContainsKey("money"))
            {
                string strName = NavigationContext.QueryString["name"].ToString();
                bool isActive = bool.Parse(NavigationContext.QueryString["isactive"].ToString());
                float fMoney = float.Parse(NavigationContext.QueryString["money"].ToString());

                AddNewCost(strName, isActive, fMoney);
            }
        }



        // Конструктор
        public MainPage()
        {

            CostsDB = new CostsDataContext(CostsDataContext.DBConnectionString);
            this.DataContext = this;


            InitializeComponent();




            //MyDatabase.Init();
            //DrawList();

            BuildLocalizedApplicationBar();
            


            // Пример кода для локализации ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        // Меню - Подсчет
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    float fActive = 0f;
        //    float fPassive = 0f;
        //    float fItog = 0f;

        //    for (int i = 0; i < MyDatabase.Values.Count; i++)
        //    {
        //        if (MyDatabase.Values[i].Active)
        //        {
        //            fActive += MyDatabase.Values[i].Money;
        //        }
        //        else
        //        {
        //            fPassive += MyDatabase.Values[i].Money;
        //        }
        //    }

        //    fItog = fActive - fPassive;

        //    MessageBox.Show(
        //                "Доходы:  " + fActive.ToString() + "\n" +
        //                "Расходы: " + fPassive.ToString() + "\n\n" +
        //                "Итого:   " + fItog.ToString()
        //                );
        //}

        //// Меню - Добавить
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/PageAdd.xaml", UriKind.Relative));
        //}

        //// Меню - Удалить
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    int nIndex = lstElements.SelectedIndex;

        //    if (-1 != nIndex)
        //    {
        //        MyDatabase.Values.RemoveAt(nIndex);
        //        DrawList();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Элемент не выбран.");
        //    }
        //}


        // Пример кода для сборки локализованной панели ApplicationBar

        private void AddNewCost(string strName, bool isActive, float fMoney)
        {
            Cost newCost = new Cost { Name = strName, IsActive = isActive, Money = fMoney };
            Costs.Add(newCost);

            CostsDB.Costs.InsertOnSubmit(newCost);
            CostsDB.SubmitChanges();
        }

        private void DeleteCost(int index)
        {
            if ((index > 0) && (index < listCosts.Items.Count))
            {
                Cost costForDelete = listCosts.Items[index] as Cost;

                Costs.Remove(costForDelete);
                CostsDB.Costs.DeleteOnSubmit(costForDelete);

                CostsDB.SubmitChanges();

                this.Focus();
            }
            else
            {
                MessageBox.Show("Индекс вне границ массива.");
            }
        }


        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("add.png", UriKind.Relative);
            button1.Text = "Add";
            ApplicationBar.Buttons.Add(button1);
            button1.Click += new EventHandler(AddNewCost());

            ApplicationBarIconButton button2 = new ApplicationBarIconButton();
            button2.IconUri = new Uri("delete.png", UriKind.Relative);
            button2.Text = "Delete";
            ApplicationBar.Buttons.Add(button2);
            button2.Click += new EventHandler(DeleteCost);

            //    ApplicationBarIconButton button3 = new ApplicationBarIconButton();
            //button3.IconUri = new Uri("next.png", UriKind.Relative);
            //button3.Text = "Count";
            //    ApplicationBar.Buttons.Add(button3);
            //    button3.Click += new EventHandler(button3_Click);
        }
    }
}