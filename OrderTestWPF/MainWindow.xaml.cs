using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace OrderTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Capch capch = null;

        public List<Capch> capches = new List<Capch>
        {
            new Capch{ IsTru="F13" , path = "/Image/F13.png"} ,
            new Capch{ IsTru="G7H" , path = "/Image/G7H.png"} ,
            new Capch{ IsTru="NOZ" , path = "/Image/NOZ.png"} ,
        };

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            Title = "Вход";
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RandomCapcha();
        }

        private void RandomCapcha()
        {
            Random random = new Random();
            var newcapch = capches[random.Next(capches.Count)];

            if(capch == null)
            {
                capch = newcapch;
                imageCapch.Source = new BitmapImage(new Uri(capch.path, UriKind.Relative));
                return;
            }

            if (capch.IsTru != newcapch.IsTru)
            {
                capch = newcapch;
                imageCapch.Source = new BitmapImage(new Uri(capch.path, UriKind.Relative));
                return;
            }

            if (capch.IsTru != newcapch.IsTru)
            {
                RandomCapcha();
            }
        }

        /// <summary>
        /// Авторизация для пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            DB.Users users = null;
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                users = myContext.users.SingleOrDefault(x => x.Login == tbLogin.Text && x.Password == tbPassword.Text );
                if (users == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                else
                {
                    MessageBox.Show("Пользователь найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (tbCaptch.Text != capch.IsTru)
            {
                MessageBox.Show(" Вы введи не правельную  капчу - Блокировка на  10 секунд ");
                for (int i = 10; i > 0; i--)
                {
                    this.Title = $"блокировка {i}  cек";
                    Thread.Sleep(1000);
                }

                RandomCapcha();
                tbCaptch.Clear();
                Title = "Вход";
                return;
            }

            if (users.Status == "admin") // если авторизовался админ
            {
                MyForms.AdminWindow adminWindow = new MyForms.AdminWindow();
                adminWindow.Show();
                Close();
            }

            if(users.Status == "user") // если авторизовался обычный пользователь
            {
                MyForms.UserWindow userWindow = new MyForms.UserWindow();
                userWindow.Show();
                Close();
            }

            if(users.Status == "manager") // если авторизовался менеджер 
            {
                MyForms.ManagerWindow managerWindow = new MyForms.ManagerWindow();
                managerWindow.Show();
                Close();
            }
        }

        /// <summary>
        /// Авторизация для гостя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntryGuest_Click(object sender, RoutedEventArgs e)
        {
            MyForms.GuestWindow guestWindow = new MyForms.GuestWindow();
            guestWindow.Show();
            Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RandomCapcha();
        }
    }

    public class Capch
    {
        public string path { get; set; }
        public string IsTru { get; set; }
    }
}
