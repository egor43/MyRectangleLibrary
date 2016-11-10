using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RectangleLbr
{
    /// <summary>
    /// Представляет прямоугольник
    /// </summary>
    public class MyRectangle
    {

        #region Поля

        private double width;
        private double length;

        #endregion

        #region Свойства

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Отрицательное значение недопустимо"); //Проверка на корректность введенных данность
                width = value;
            }
        }

        /// <summary>
        /// Длинна прямоугольника
        /// </summary>
        public double Length
        {
            get
            {
                return length;
            }

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Отрицательное значение недопустимо"); //Проверка на корректность введенных данность
                length = value;
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует новый экземпляр класса с указанными значениями
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="length">Длина</param>
        public MyRectangle(double width, double length)
        {
            Width = width;
            Length = length;
        }

        #endregion

        #region Методы

        public virtual double GetArea()
        {
            return Width * Length;
        }

        public virtual double GetPerimeter()
        {
            if ((Width == 0) || (Length == 0))
            {
                if (Width == 0) return Length;
                return Width;
            }
            return 2 * (Width + Length);
        }

        public virtual string About()
        {
            return "Rectangle";
        }

        public static bool operator <(MyRectangle object1, MyRectangle object2)
        {
            if (object1.GetArea() < object2.GetArea()) return true;
            return false;
        }

        public static bool operator >(MyRectangle object1, MyRectangle object2)
        {
            if (object1.GetArea() > object2.GetArea()) return true;
            return false;
        }

        #endregion

    }

    /// <summary>
    /// Предсталяет параллелепипед
    /// </summary>
    public class MyVolumeRectangle : MyRectangle
    {
        #region Поля

        private double height;

        #endregion

        #region Свойства

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Отрицательное значение недопустимо");
                height = value;
            }
        }

        #endregion

        #region Конструкторы

        public MyVolumeRectangle(double width, double length, double height)
            : base(width, length)
        {
            Height = height;
        }

        #endregion

        #region Методы

        public override double GetArea()
        {
            return 2 * (Width * Height + Length * Height + Length * Width);
        }

        public override double GetPerimeter()
        {
            if ((Width == 0) || (Length == 0) || (Height == 0))
            {
                if (Height == 0) return base.GetPerimeter();
                if (Width == 0)
                {
                    if (Length == 0) return Height;
                    return 2 * (Length + Height); ;
                }
                return 2 * (Width + Height); ;
            }
            return 4 * (Width + Length + Height);
        }

        public double GetVolume()
        {
            return Width * Length * Height;
        }

        public override string About()
        {
            return "VolumeRectangle";
        }

        public static bool operator <(MyVolumeRectangle object1, MyVolumeRectangle object2)
        {
            if (object1.GetVolume() < object2.GetVolume()) return true;
            return false;
        }

        public static bool operator >(MyVolumeRectangle object1, MyVolumeRectangle object2)
        {
            if (object1.GetVolume() > object2.GetVolume()) return true;
            return false;
        }

        #endregion
    }
}
