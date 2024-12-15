using SignalGenLib;
using SignalGenInterfaceLib;
namespace lab4Metoda
{
    public partial class Form1 : Form
    {
        const double discFreq = 1000;   //������� ������������ �������(��)
        const int numOfSamples = 2000; //��������� ���������� �������(�����) � ������������ �������

        ISignalGenerator gen = new SignalGenerator();
        Filter filter = new Filter(Filter.CalcSecondOrder(100, discFreq)); //������������� ������� �����������
        
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
            graphPlot.Plot.Clear(); //������� ������ �� ���������� ��������
            gen.GenSignal(10, 2, discFreq, numOfSamples, SignalType.MEANDER);   //���������� ������ � ����������� �� ��������.
            filter.Clean(); //������� ������ �� ������ ������

            List<double> time = new List<double>();         //������ ��� �������� ��������� ��������
            List<double> filtredData = new List<double>();  //������ ��� �������� ��������������� ������

            for (int i = 0; i < numOfSamples; i++)
            {
                time.Add(i / discFreq);                         //��������� ��������� �������� ��� �������
                filtredData.Add(filter.Calc(gen.NoisyData[i])); //���������� �������. 
            }

            //���������� ��������� ������� �� ������
            if (rawDataCheck)
            {
                var rawPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), gen.RawData.ToArray(), ScottPlot.Colors.Red);
                rawPlot.LineWidth = 2;
            }

            //���������� ������������ ������� �� ������
            if (noisyDataCheck)
            {
                var noisyPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), gen.NoisyData.ToArray(), ScottPlot.Colors.Blue);
            }

            //���������� ���������������� ������� �� ������
            if (filtredDataCheck)
            {
                var filtredPlot = graphPlot.Plot.Add.SignalXY(time.ToArray(), filtredData.ToArray(), ScottPlot.Colors.Green);
                filtredPlot.LineWidth = 4;
            }


            graphPlot.Plot.Axes.AutoScaleX();    //��������� ��������������� ��������������� �������
            graphPlot.Refresh();                //����������� �������

        }

        private void updateFilterBtn_Click(object sender, EventArgs e)
        {
            filter.Clean();
            filter.Coefs = Filter.CalcSecondOrder(Convert.ToDouble(filterFreqBox.Text), discFreq);
        }
    }
}