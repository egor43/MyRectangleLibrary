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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RectangleLbr;

namespace UserInterface
{
    /// <summary>
    /// Перечислитель типов фигуры
    /// </summary>
    public enum TypeFigure
    {
        /// <summary>
        /// Тип неопределён
        /// </summary>
        None,

        /// <summary>
        /// Прямоугольнник
        /// </summary>
        Rectangle,

        /// <summary>
        /// Параллелепипед
        /// </summary>
        VolumeRectangle
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TypeFigure Figure; //Переменная для хранения типа фигуры

        MyRectangle[] FigureArr; //Массив для хранения экземпляров обоих классов

        /// <summary>
        /// Переключает интерфейс в различные состояния. Состояния зависят от типа фигуры.
        /// </summary>
        /// <param name="condition">true - включить. false - выключить</param>
        /// <param name="figure">Тип фигуры</param>
        public void InterfaceSwitch(bool condition, TypeFigure figure)
        {
            if ((figure == TypeFigure.None) || (figure == TypeFigure.VolumeRectangle)) Height_grid.IsEnabled = condition;
            else Height_grid.IsEnabled = false;
            switch (condition)
            {
                case true:
                    {
                        Button_grid.IsEnabled = condition;
                        Width_grid.IsEnabled = condition;
                        Length_grid.IsEnabled = condition;
                        Width1_txtb.Text = "";
                        Length1_txtb.Text = "";
                        Height1_txtb.Text = "";
                        Width2_txtb.Text = "";
                        Length2_txtb.Text = "";
                        Height2_txtb.Text = "";
                        break;
                    }
                case false:
                    {
                        Width1_txtb.Text = "";
                        Length1_txtb.Text = "";
                        Height1_txtb.Text = "";
                        Width2_txtb.Text = "";
                        Length2_txtb.Text = "";
                        Height2_txtb.Text = "";
                        Button_grid.IsEnabled = condition;
                        Width_grid.IsEnabled = condition;
                        Length_grid.IsEnabled = condition;
                        break;
                    }
            }
        }

        /// <summary>
        /// Выводит информацию о фигурах в Result_txtb
        /// </summary>
        /// <param name="list">Коллекция фигур</param>
        public void PrintInformation(List<MyRectangle> list)
        {
            int count = 1;
            Result_txtb.Text += "\n";
            foreach (var v in list)
            {
                Result_txtb.Text += "\n";
                Result_txtb.Text += v.About() +" " + count.ToString() + "\n";
                Result_txtb.Text += "Площадь: " + v.GetArea().ToString() + "\n";
                Result_txtb.Text += "Периметр: " + v.GetPerimeter().ToString() + "\n";
                if (v is MyVolumeRectangle)
                {
                    MyVolumeRectangle s = v as MyVolumeRectangle;
                    Result_txtb.Text += "Объем: " + s.GetVolume().ToString() + "\n";
                }
                count++;
            }
        }

        /// <summary>
        /// Начальная инициализация
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Figure = TypeFigure.None;
            InterfaceSwitch(false, Figure);
        }

        /// <summary>
        /// Обработчик выбора RadioButton - прямоугольник
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">дополнительная информация</param>
        private void Rectangle_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            Figure = TypeFigure.Rectangle;
            InterfaceSwitch(true, Figure);
        }

        /// <summary>
        /// Обработчик выбора RadioButton - параллелепипед
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">дополнительная информация</param>
        private void Volumectangle_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            Figure = TypeFigure.VolumeRectangle;
            InterfaceSwitch(true, Figure);
        }

        /// <summary>
        /// Обработчик кнопки Создать фигуры
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">дополнительная информация</param>
        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Figure == TypeFigure.Rectangle)
            {
                bool flag = true;                                                               
                double length1 = 0, length2 = 0, width1 = 0, width2 = 0;                        
                if ((Double.TryParse(Width1_txtb.Text, out width1) != true) || (width1 < 0))    //
                {                                                                               //
                    Width1_txtb.Text = "Ошибка!";                                               //
                    flag = false;                                                               //
                }                                                                               //
                if ((Double.TryParse(Width2_txtb.Text, out width2) != true) || (width2 < 0))    //
                {                                                                               //
                    Width2_txtb.Text = "Ошибка!";                                               //
                    flag = false;                                                               //
                }                                                                               // Проверка введенных значений в поля для заполнения
                if ((Double.TryParse(Length1_txtb.Text, out length1) != true) || (length1 < 0)) //
                {                                                                               //
                    Length1_txtb.Text = "Ошибка!";                                              //
                    flag = false;                                                               //
                }                                                                               //
                if ((Double.TryParse(Length2_txtb.Text, out length2) != true) || (length2 < 0)) //
                {                                                                               //
                    Length2_txtb.Text = "Ошибка!";                                              //
                    flag = false;                                                               //
                }                                                                               //
                if (flag)
                {
                    List<MyRectangle> list = new List<MyRectangle>(); // Коллекция нужна для передачи ее в метод  PrintInformation()
                    list.Add(new MyRectangle(width1, length1));
                    list.Add(new MyRectangle(width2, length2));
                    PrintInformation(list);
                    if (list[0] > list[1]) Result_txtb.Text += "Первый прямоугольник больше, чем второй \n";
                    else if (list[0] < list[1]) Result_txtb.Text += "Второй прямоугольник больше, чем первый \n";
                    else Result_txtb.Text += "Прямоугольники равны \n";
                    Result_txtb.ScrollToEnd();
                }
            }
            else if (Figure == TypeFigure.VolumeRectangle)
            {
                bool flag = true;
                double length1 = 0, length2 = 0, width1 = 0, width2 = 0,height1=0,height2=0;
                if ((Double.TryParse(Width1_txtb.Text, out width1) != true) || (width1 < 0))    //
                {                                                                               //
                    Width1_txtb.Text = "Ошибка!";                                               //
                    flag = false;                                                               //
                }                                                                               //
                if ((Double.TryParse(Width2_txtb.Text, out width2) != true) || (width2 < 0))    //
                {                                                                               //
                    Width2_txtb.Text = "Ошибка!";                                               //
                    flag = false;                                                               //
                }                                                                               // 
                if ((Double.TryParse(Length1_txtb.Text, out length1) != true) || (length1 < 0)) //
                {                                                                               //
                    Length1_txtb.Text = "Ошибка!";                                              //
                    flag = false;                                                               //
                }                                                                               // Проверка введенных значений в поля для заполнения
                if ((Double.TryParse(Length2_txtb.Text, out length2) != true) || (length2 < 0)) //
                {                                                                               //
                    Length2_txtb.Text = "Ошибка!";                                              //
                    flag = false;                                                               //
                }                                                                               //
                if ((Double.TryParse(Height1_txtb.Text, out height1) != true) || (height1 < 0)) //
                {                                                                               //
                    Height1_txtb.Text = "Ошибка!";                                              //    
                    flag = false;                                                               //
                }                                                                               //
                if ((Double.TryParse(Height2_txtb.Text, out height2) != true) || (height2 < 0)) //
                {                                                                               //
                    Height2_txtb.Text = "Ошибка!";                                              //
                    flag = false;                                                               //
                }                                                                               //
                if (flag)
                {
                    List<MyRectangle> list = new List<MyRectangle>(); // Коллекция нужна для передачи ее в метод  PrintInformation()
                    list.Add(new MyVolumeRectangle(width1, length1,height1));
                    list.Add(new MyVolumeRectangle(width2, length2,height2));
                    PrintInformation(list);
                    if (list[0] > list[1]) Result_txtb.Text += "Первый прямоугольник больше, чем второй \n";
                    else if (list[0] < list[1]) Result_txtb.Text += "Второй прямоугольник больше, чем первый \n";
                    else Result_txtb.Text += "Прямоугольники равны \n";
                    Result_txtb.ScrollToEnd();
                }
            }
            else
            {
                Result_txtb.Text = "Ошибка! Не выбрана фигура";
            }
        }

        /// <summary>
        /// Обработчик кнопки Случайные фигуры
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">дополнительная информация</param>
        private void RandomCreate_btn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            FigureArr = new MyRectangle[2];
            FigureArr[0] = new MyRectangle(rnd.Next(1000), rnd.Next(1000));
            FigureArr[1] = new MyVolumeRectangle(rnd.Next(1000), rnd.Next(1000),rnd.Next(1000));
            List<MyRectangle> list = new List<MyRectangle>(); // Коллекция нужна для передачи ее в метод  PrintInformation()
            list.Add(FigureArr[0]);
            list.Add(FigureArr[1]);
            PrintInformation(list);
            Result_txtb.ScrollToEnd();
        }

        /// <summary>
        /// Обработчик кнопки Очистить
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">дополнительная информация</param>
        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Figure == TypeFigure.Rectangle) Rectangle_rbtn.IsChecked = false;
            if (Figure == TypeFigure.VolumeRectangle) Volumectangle_rbtn.IsChecked = false;
            Figure = TypeFigure.None;
            Result_txtb.Text = "";
            InterfaceSwitch(false, Figure);
        }
    }
}
