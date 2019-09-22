using FoodProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
      

        private const string URL = "http://localhost:53926/api/Food";
        FoodDAOMSSQL foodDao = null;
        List<Food> foods = new List<Food>();
        public MainWindow()
        {
            foodDao = new FoodDAOMSSQL();
            InitializeComponent();
            foods = foodDao.GetAllFoods();
            grid.ItemsSource = foods;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foods = foodDao.GetAllFoods();
            grid.ItemsSource = foods;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ViewAddFood viewAddFood = new ViewAddFood();
            viewAddFood.Show();
        }
    }
}

