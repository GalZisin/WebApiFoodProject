using FoodProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoodWPFProject
{
    /// <summary>
    /// Interaction logic for ViewAddFood.xaml
    /// </summary>
    public partial class ViewAddFood : Window
    {
        FoodDAOMSSQL foodDao = null;
        public ViewAddFood()
        {
            foodDao = new FoodDAOMSSQL();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Food food = new Food
            {
                Name = name.Text,
                Calories = Convert.ToInt32(calories.Text),
                Grade = Convert.ToInt32(grade.Text),
                Ingridients = ingredients.Text
            };

            foodDao.AddFood(food);
        }
    }
}
