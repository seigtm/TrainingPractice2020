using System;
using System.Windows.Forms;
using System.Threading;

namespace EratosthenesSieve
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        // Заполнение таблицы числами [2..lastNumber].
        private void FillTable(uint lastNumber)
        {
            uint currentNumber = 2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = currentNumber++;
                    if (currentNumber > lastNumber)
                    {
                        return;
                    }
                }
            }
        }

        // Визуализация вычёркивания простых чисел в таблице.
        private void ColorNotPrimary(uint n)
        {
            uint step = 1; // Шаг цикла.
            for (int number = 2; number < Math.Sqrt(n) + 1; number++)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        int currentNumber = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        if (currentNumber % number == 0 && currentNumber != number)
                        {
                            // Выделяем серым кратные числа.
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Gray;
                        }
                    }
                }
                // Обновляем данные о текущей итерации.
                labelStep.Text = "Шаг №" + step++.ToString();
                labelCurrentActive.Text = "Вычёркиваем кратные " + number.ToString();
                Refresh();          // Обновляем интерфейс.
                Thread.Sleep(2000); // Задержка на 2 секунды.
            }
            labelStep.Text = "Ушло шагов: " + step.ToString();
            labelCurrentActive.Text = "Остались только простые числа!";
        }

        // Нажатие на кнопку "Вычислить".
        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            // Очищаем таблицу с каждым нажатием кнопки.
            dataGridView1.Rows.Clear();

            // Проверяем, является ли введённая строка беззнаковым целым числом.
            if (!uint.TryParse(textBox1.Text, out uint n)) // n - конечное число диапазона.
            {
                MessageBox.Show("Введите целое число!");
                return;
            }

            // rows, columns - ряды и колонки таблицы.
            // Вычисляются как корень квадратный из n.
            int rows = Convert.ToInt32(Math.Sqrt(n));
            int columns = Convert.ToInt32(Math.Sqrt(n));
            // Если корень извлекается не целым.
            // То нам необходимо нарисовать на один ряд больше,
            //  чтобы поместить все числа в таблице.
            if (rows - Math.Sqrt(n - 1) < 0) // n - 1, т.к. диапазон у нас - [2...n].
            {
                rows++;
            }
            // Устанавливаем количество рядов и колонок таблицы тут.
            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = columns;

            // Заполняем таблицу числами от 2 до n.
            FillTable(n);

            // Визуализируем алгоритма удаления кратных чисел.
            ColorNotPrimary(n);
        }
    }
}
