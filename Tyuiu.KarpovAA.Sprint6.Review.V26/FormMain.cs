using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tyuiu.KarpovAA.Sprint6.Review.V26.Lib;

namespace Tyuiu.KarpovAA.Sprint6.Review.V26
{
    public partial class FormMain : Form
    {

        DataService ds = new DataService();
                        
        public int[,] valueArray;
        public int countRow;
        public int countColumns;
        public int startX;
        public int endX;
        public int massiveStart;
        public int massiveEnd;
        public int selectedR;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCreateMatrix_KAA_Click(object sender, EventArgs e)
        {
            try
            {
                countRow = Convert.ToInt32(textBoxCountRow_KAA.Text);
                countColumns = Convert.ToInt32(textBoxCountColums_KAA.Text);
                startX = Convert.ToInt32(textBoxStartDiap_KAA.Text);
                endX = Convert.ToInt32(textBoxEndDiap_KAA.Text);

                Random rnd = new Random();

                valueArray = new int[countRow, countColumns];

                dataGridViewOutPut_KAA.RowCount = valueArray.GetLength(0);
                dataGridViewOutPut_KAA.ColumnCount = valueArray.GetLength(1);

                
                bool[] isNegative = new bool[countColumns];
                for (int j = 0; j < countColumns; j++)
                {
                    
                    isNegative[j] = rnd.Next(0, 2) == 0;
                }

                for (int i = 0; i < countRow; i++)
                {
                    for (int j = 0; j < countColumns; j++)
                    {
                        valueArray[i, j] = rnd.Next(startX, endX);

                        
                        if (isNegative[j])
                        {
                            valueArray[i, j] *= -1;
                        }

                        
                        isNegative[j] = !isNegative[j];

                        dataGridViewOutPut_KAA.Rows[i].Cells[j].Value = valueArray[i, j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonResult_KAA_Click(object sender, EventArgs e)
        {
            try
            {
                massiveStart = Convert.ToInt32(textBoxStartMassive_KAA.Text);
                massiveEnd = Convert.ToInt32(textBoxEndMassive_KAA.Text);
                selectedR = Convert.ToInt32(textBoxSelectedRow_KAA.Text);

                
                if (valueArray != null && selectedR >= 0 && selectedR < countRow)
                {
                    int res = ds.GetMatrix(valueArray, selectedR, massiveStart, massiveEnd);
                    textBoxResult_KAA.Text = Convert.ToString(res);
                }
                else
                {
                    MessageBox.Show("Матрица не инициализирована или выбрана неверная строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные для выполнения вычислений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
