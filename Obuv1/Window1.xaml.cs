using Obuv1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Obuv1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public string imag { get; set; } // создаем переменную для картинки
        public static int quantity;  // создаем переменную для количества обуви
        public Window1(int tag)
        {
            InitializeComponent();

            this.DataContext = this;
            OrderBtn.Tag = tag; //передаем кнопке тeг
         
            using (SqlConnection sqlConection = new SqlConnection())  // подключение к бд
            { 

               sqlConection.ConnectionString = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Obuv"; // адрес подключения
               SqlCommand command = new SqlCommand(); //создание команды
                SqlCommand commandUpdate = new SqlCommand();
                SqlDataReader reader = null; // считывание данных
                
                try
                {
                    if(sqlConection != null) // если conection не равен нулю
                    {   
                        sqlConection.Open();    //открываем соединение
                        command.Connection = sqlConection; // передаем в команд соединение
                        commandUpdate.Connection = sqlConection;

                       command.CommandText = "SELECT * FROM Shoes WHERE ID = "+tag; //создаем запрос
                        reader = command.ExecuteReader(); // выполняем

                        while (reader.Read()) //считываем данные
                        {
                            imag = reader.GetString(1); //присваиваем картинку из бд
                            discp.Text = reader.GetString(7); // присвоить описание из бд
                            Size.Text = reader.GetInt32(4).ToString(); // присвоить размер из бд
                            Price.Text = reader.GetSqlMoney(6).ToString() + " Рублей"; // присвоить цену из бд
                            quantity = reader.GetInt32(5); // присвоить количество из бд
                        }
                    }
                }
                finally
                {
                    if (sqlConection != null) 
                    { 
                        sqlConection.Close(); //закрываем соединение
                    }
                    if (!reader.IsClosed) 
                    {
                        reader.Close(); // закрываем счтьывание
                    }
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwin = new MainWindow();
            this.Close();
            mainwin.Show();
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text.Trim();
            string surname = Surname.Text.Trim();
            string city = City.Text.Trim();
            string address = Address.Text.Trim();
            string phone = Phone.Text.Trim();

            Regex regex = new Regex(@"^[A-Za-zА-яЁё]+$"); //проверка имени и фамилии
            Match nam = regex.Match(name);
            Match sur = regex.Match(surname);

            Regex regexC = new Regex(@"^[а-яёА-ЯЁ]+(?:[\s-][а-яёА-ЯЁ]+)*$"); // Проверка города
            Match cit = regexC.Match(city);

            Regex regexA = new Regex(@"^[а-яА-ЯёЁa-zA-Z\s]+[0-9.\\/]+[а-яА-ЯёЁa-zA-Z\s]*[0-9]*$"); //проверка адреса
            Match adres = regexA.Match(address);

            Regex regexP = new Regex(@"^((\+7|7|8)+([0-9]){10})$"); //проверка номера телефона
            Match phon = regexP.Match(phone);

            bool flagN = false;
            bool flagS = false;
            bool flagC = false;
            bool flagA = false;
            bool flagP = false;


            // Проверки на правильность вводимых данных 
            if (nam.Success != true)
            {
                Name.ToolTip = "Неправильно введено имя! Имя должно состоять из кириллицы или латиницы";
                Name.Background = Brushes.DarkRed;
                flagN = false;
            }
            else
            {
                Name.ToolTip = "";
                Name.Background = Brushes.Transparent;
                flagN = true;
            }
            if (sur.Success != true)
            {
                Surname.ToolTip = "Неправильно введена фамилия! Фамилия должна состоять из кириллицы или латиницы";
                Surname.Background = Brushes.DarkRed;
                flagS = false;
            }
            else 
            {
                Surname.ToolTip = "";
                Surname.Background = Brushes.Transparent;
                flagS = true;
            }
            if (cit.Success != true)
            {
                City.ToolTip = "Неправильно введен город";
                City.Background = Brushes.DarkRed;
                flagC = false;
            }
            else
            {
                City.ToolTip = "";
                City.Background = Brushes.Transparent;
                flagC = true;
            }
            if (adres.Success != true)
            {
                Address.ToolTip = "Неправильно введен адрес! Адрес должен иметь вид: ул Первомайская д15 кв5";
                Address.Background = Brushes.DarkRed;
                flagA = false;
            }
            else
            {
                Address.ToolTip = "";
                Address.Background = Brushes.Transparent;
                flagA = true;
            }
            if (phon.Success != true)
            {
                Phone.ToolTip = "Неправильно введен номер телефона";
                Phone.Background = Brushes.DarkRed;
                flagP = false;
            }
            else
            {
                Phone.ToolTip = "";
                Phone.Background = Brushes.Transparent;
                flagP = true;
            }

            if(flagN == true && flagS == true && flagC == true && flagA == true && flagP == true) //если все флаги равны true то выполнить
            {
                if (quantity > 0) //если кол-во обуви не равно 0  
                {
                    Order_ order = new Order_(); // создаем order типа таблицы Order_ из бд

                    //инициализируем
                    order.Name_ = Name.Text.Trim();
                    order.Surname = Surname.Text.Trim();
                    order.City = City.Text.Trim();
                    order.Address_ = Address.Text.Trim();
                    order.Phone = Phone.Text.Trim();
                    order.Id_Shoes = (int)OrderBtn.Tag;


                    AppData.db.Order_.Add(order); //добавляем новую запись в бд

                    using (SqlConnection sqlConection = new SqlConnection())  // подключение к бд
                    {
                        sqlConection.ConnectionString = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Obuv"; // адрес подключения
                        SqlCommand commandUpdate = new SqlCommand();
                        try
                        {
                            if (sqlConection != null) // если conection не равен нулю
                            {
                                sqlConection.Open();    //открываем соединение
                                commandUpdate.Connection = sqlConection;
                                commandUpdate.CommandText = "UPDATE Shoes SET Quantity = Quantity - 1 WHERE ID = " + OrderBtn.Tag; //запрос на уменьшение количество обуви
                                commandUpdate.ExecuteNonQuery();

                            }
                        }
                        finally
                        {
                            if (sqlConection != null)
                            {
                                sqlConection.Close(); //закрываем соединение
                            }
                        }
                    }


                    AppData.db.SaveChanges(); //сохранение изменений в бд



                    MessageBox.Show("Заказ успешно оформлен!");

                }
                else
                {
                    MessageBox.Show("Заказ не оформлен. Данного товара в наличие нет");
                }
            }
            else
            {
                MessageBox.Show("Заполните верно поля. Для подсказки наведите курсор на поле");
            }
           

        }

      
    }
}
