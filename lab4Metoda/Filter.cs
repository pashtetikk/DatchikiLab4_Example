using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Metoda
{
    internal class Filter
    {
        private List<double> coefs;     //Массив внутренних коэффициентов фильтра
        private double y = 0, x1 = 0, x2 = 0, y1 = 0, y2 = 0;   //Переменные для хранения внутреннего состояния фильтра
        
        //Конструкторы
        public Filter()
        {
            coefs = new List<double>() { 0, 0, 0, 0, 0 };
        }
        public Filter(List<double> _coefs)
        {
            coefs = _coefs;
        }

        //Функция расчета фильтра. Каждое новое входное значение отправляется в эту функцию
        //для фильтрации. Функция возвращает отфильтрованное значение
        public double Calc(double inData)
        {
            y = x2 * coefs[4] + x1 * coefs[3] + inData * coefs[2] - y2 * coefs[1] - y1 * coefs[0];
            x2 = x1;
            x1 = inData;
            y2 = y1;
            y1 = y;
            return y;
        }

        public List<double> Coefs {
            set { coefs = value; }
            get { return coefs; } 
        }
        
        //Очистка фильтра
        public void Clean()
        {
            y = 0;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }

        //Функция расчета коэффициентов филтра для первого порядка
        public static List<double> CalcFirstOrder(double freq, double sampleRate)
        {
            double T = 1 / sampleRate;
            double omegaC = 2 * Math.PI * freq;
            double a0 = omegaC + 2 / T;
            double a1 = (omegaC - 2 / T) / a0;
            double b0 = omegaC / a0;
            return new List<double>() { a1, 0, b0, b0, 0 };
        }

        //Функция расчета коэффициентов филтра для второго порядка
        public static List<double> CalcSecondOrder(double freq, double sampleRate)
        {
            double T = 1 / sampleRate;
            double omegaC = 2 * Math.PI * freq;
            double a0 = Math.Pow(omegaC, 2) + 2 * Math.Pow(2, 0.5) * omegaC / T + 4 / Math.Pow(T, 2);
            double a1 = (2 * Math.Pow(omegaC, 2) - 8 / Math.Pow(T, 2)) / a0;
            double a2 = (Math.Pow(omegaC, 2) - 2 * Math.Pow(2, 0.5) * omegaC / T + 4 / Math.Pow(T, 2)) / a0;
            double b0 = Math.Pow(omegaC, 2) / a0;
            double b1 = 2 * Math.Pow(omegaC, 2) / a0;
            double b2 = b0;

            return new List<double>() { a1, a2, b0, b1, b2 };
        }
    }
}
