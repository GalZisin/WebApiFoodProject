using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodProject
{
    public class FoodDAOMSSQL
    {
       
        public List<Food> GetAllFoods()
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                List<Food> foods = (from f in foodDBEntities.Foods
                                           select f).ToList();
          
                return foods;
            }
        }
        public Food GetfoodById(int id)
        {
             
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {

                Food food = foodDBEntities.Foods.FirstOrDefault(f => f.ID == id);
                return food;

            }
        }
        public void AddFood(Food food)
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                foodDBEntities.Foods.Add(food);
                foodDBEntities.SaveChanges();
            }
        }
        public void UpdateFood(int id, Food food) 
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                Food result = foodDBEntities.Foods.FirstOrDefault(f => f.ID == id);
                if (result != null)
                {
                    result.Name = food.Name;
                    result.Ingridients = food.Ingridients;
                    result.Calories = food.Calories;
                    foodDBEntities.SaveChanges();
                }
            }
                
        }
        public void DeleteFood(int id) 
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                Food result = foodDBEntities.Foods.FirstOrDefault(f => f.ID == id);
                if (result != null)
                    foodDBEntities.Foods.Remove(result);
                foodDBEntities.SaveChanges();
            }

        }
        public List<Food> GetByFoodName(string name)
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                List<Food> results = foodDBEntities.Foods.Where(m => m.Name.ToUpper() == name.ToUpper()).ToList();
                                    
                return results;
            }

        }
        public List<Food> GetFoodBiggerthanCal(int mincal)
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                List<Food> foods = foodDBEntities.Foods.Where(m => m.Calories > mincal).ToList();

                return foods;
            }
        }
        public List<Food> GetByFilter(string name = "", int maxcal = 0, int mincal =0, string ingridients = "", int grade =0)
        {
            using (FoodDBEntities foodDBEntities = new FoodDBEntities())
            {
                if (name == "" && mincal == 0 && maxcal ==0 && ingridients =="" && grade != 0)
                    return foodDBEntities.Foods.Where(m => m.Grade == grade).ToList();
                if(name == "" && mincal == 0 && maxcal == 0 && ingridients != "" && grade == 0)
                    return foodDBEntities.Foods.Where(m => m.Ingridients.ToUpper().Contains(ingridients.ToUpper())).ToList();
                if (name == "" && mincal == 0 && maxcal != 0 && ingridients == "" && grade == 0)
                    return foodDBEntities.Foods.Where(m => m.Calories <= maxcal).ToList();
                if (name == "" && mincal != 0 && maxcal == 0 && ingridients == "" && grade == 0)
                    return foodDBEntities.Foods.Where(m => m.Calories >= mincal).ToList();
                if (name != "" && mincal == 0 && maxcal == 0 && ingridients == "" && grade == 0)
                    return foodDBEntities.Foods.Where(m => m.Name.ToUpper().Contains(name.ToUpper())).ToList();
                if (name == "" && mincal != 0 && maxcal != 0 && ingridients == "" && grade == 0)
                    return foodDBEntities.Foods.Where(m => m.Calories >= mincal && m.Calories <= maxcal).ToList();
                return foodDBEntities.Foods.Where(m => m.Name.ToUpper().Contains(name.ToUpper()) || (ingridients != "" && m.Ingridients.ToUpper().Contains(ingridients.ToUpper())) || m.Grade == grade || (mincal> 0 && maxcal==0 && m.Calories >=mincal) || (mincal==0 && maxcal > 0 && m.Calories <=maxcal)|| (mincal > 0 && maxcal > 0 && m.Calories >= mincal && m.Calories <= maxcal)).ToList();

            }
           
        }
    }
    
}


