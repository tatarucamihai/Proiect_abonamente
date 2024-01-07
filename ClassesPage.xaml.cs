using Proiect_abonamente.Models;

namespace Proiect_abonamente
{
    public partial class ClassesPage : ContentPage
    {
        public ClassesPage(Subscription selectedSubscription)
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            
            Class classData1 = new Class
            {
                Title = "Acces nelimitat",
                Description = "Participați la orice clasă disponibilă.",
                DayOfWeek = "Luni",
                ClassName = "Yoga",
                Time = "18:00 - 19:30"
            };

            Class classData2 = new Class
            {
                Title = "Fitness intensiv",
                Description = "Sesiuni intense de fitness pentru a vă menține în formă.",
                DayOfWeek = "Miercuri",
                ClassName = "HIIT",
                Time = "17:00 - 18:00"
            };

            Class classData3 = new Class
            {
                Title = "Yoga de relaxare",
                Description = "Oferă momente de relaxare și echilibrare.",
                DayOfWeek = "Vineri",
                ClassName = "Yoga",
                Time = "20:00 - 21:00"
            };

           
            List<Class> classes = new List<Class> { classData1, classData2, classData3 };

           
            BindingContext = classes;
        }
    }
}
