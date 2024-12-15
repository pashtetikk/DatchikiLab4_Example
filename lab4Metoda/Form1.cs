using SignalGenLib;
using SignalGenInterfaceLib;
namespace lab4Metoda
{
    public partial class Form1 : Form
    {
        const double discFreq = 1000;   //Частота дисретизации сигнала(Гц)
        const int numOfSamples = 2000; //Суммарное количество сэмплов(точек) в генерируемом сигнале

        ISignalGenerator gen = new SignalGenerator();
        Filter filter = new Filter(Filter.CalcSecondOrder(100, discFreq)); //Инициализация фильтра Баттерворта
        
        private bool rawDataCheck = true, noisyDataCheck = false, filtredDataCheck = false;

        public Form1()
        {
            InitializeComponent();
            graphPlot.Plot.Title("Graph");
            graphPlot.Plot.XLabel("Time, c");
            graphPlot.Plot.YLabel("Amplitude");
        }

        private void ClearDataCB_CheckedChanged(object sender, EventArgs e)
        {
            rawDataCheck = ((CheckBox)sender).Checked;
        }

        private void NoisyDataCB_CheckedChanged(object sender, EventArgs e)
        {
            noisyDataCheck = ((CheckBox)sender).Checked;
        }

        private void filtredDataCB_CheckedChanged(object sender, EventArgs e)
        {
            filtredDataCheck = ((CheckBox)sender).Checked;
        }

        private void updateGraphBtn_Click(object sender, EventArgs e)
        {
            graphPlot.Plot.Clear(); //Очищаем график от предыдущих значений
            gen.GenSignal(10, 2, discFreq, numOfSamples, SignalType.MEANDER);   //Генерируем сигнал с параметрами по варианту.
            filter.Clean(); //Очищаем фильтр на всякий случай

            List<double> time = new List<double>();         //Массив для хранения временных отсчетов
            List<double> filtredData = new List<double>();  //Массив для хранения отфильтрованных данных

            for (int i = 0; i < numOfSamples; i++)
            {
                time.Add(i / discFreq);                         //Генерация временных отсчетов для графика
                filtredData.Add(filter.Calc(gen.NoisyData[i])); //Фильтрация сигнала. 
            }

            //Добавление исходного сигнала на график
            if (rawDataCheck)
            {
                var rawPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), gen.RawData.ToArray(), ScottPlot.Colors.Red);
                rawPlot.LineWidth = 2;
            }

            //Добавление зашумленного сигнала на график
            if (noisyDataCheck)
            {
                var noisyPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), gen.NoisyData.ToArray(), ScottPlot.Colors.Blue);
            }

            //Добавление отфильтрованного сигнала на график
            if (filtredDataCheck)
            {
                var filtredPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), filtredData.ToArray(), ScottPlot.Colors.Green);
                filtredPlot.LineWidth = 4;
            }


            graphPlot.Plot.Axes.AutoScaleX();    //Включение автоматического масштабирования графика
            graphPlot.Refresh();                //Отображение графика

        }

        private void updateFilterBtn_Click(object sender, EventArgs e)
        {
            filter.Clean();
            filter.Coefs = Filter.CalcSecondOrder(Convert.ToDouble(filterFreqBox.Text), discFreq);
        }
    }
}