using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace EXAM_OOP_WINF
{
    public partial class Form1 : Form
    {
        // Створення списку команд
        private List<string> teams = new List<string>();
        // Створення іконки Tray
        private NotifyIcon trayIcon;
        // Змінні для запису індексів PageTab, щоб динамічно видаляти та повертати їх
        private int index_tab1;
        private int index_tab2;
        private int index_tab3;
        // Змінні підрахунку кількості команд для різних випадків
        private int count_i_team = 1;
        private int count_team;
        private int count_team_table;
        public Form1()
        {
            InitializeComponent();
            // Автоматично при старті видаляємо всі зайві TabPage та записуємо їх індекси
            index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
            tabControl1.TabPages.Remove(tabPage1);
            index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
            tabControl1.TabPages.Remove(tabPage2);
            index_tab3 = tabControl1.TabPages.IndexOf(tabPage3);
            tabControl1.TabPages.Remove(tabPage3);
            // створюємо іконку в tray
            trayIcon = new NotifyIcon();
            trayIcon.Text = "My App";
            trayIcon.Icon = new Icon("C:\\Users\\Admin\\source\\repos\\EXAM_OOP_WINF\\EXAM_OOP_WINF\\Anonymous_emblem.svg.ico");
            trayIcon.Visible = true;

            listBox_team.DataSource = teams;
            // додаємо обробник для подвійного натискання на іконці в треї.
            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            // додаємо обробник для натискання на іконці в треї.
            trayIcon.MouseClick += TrayIcon_MouseClick;
        }

        // Обробник для подвійного натискання на іконці в треї
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            // показуємо головне вікно програми
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        // Обробник для натискання на іконці в треї
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Створюємо заглушки у разі натискання на іконку один раз лівою чи правою кнопкою
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Натисніть два рази ЛКМ");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Натисніть два рази ЛКМ");
            }
        }
        // Обробник закривання форми
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            this.Hide();
        }
        // Обробник закривання форми
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // вихід з додатку
            Application.Exit();
        }
        // Обробник натискання на кнопку "Вхід"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Перевіряємо, що введено логін та пароль
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Введіть логін та пароль");
                return;
            }

            // Перевіряємо логін та пароль на відповідність
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                TabPage selectedTab = tabControl1.SelectedTab;
                // Видаляємо вибрану вкладку
                tabControl1.TabPages.Remove(selectedTab);
                // Відновити вкладку в TabControl
                tabControl1.TabPages.Insert(index_tab1 - 1, tabPage1);
                // Перемикаємось на нову вкладку
                tabControl1.SelectedTab = tabPage1;
                // Показуємо повідомлення про успішну авторизацію
                MessageBox.Show("Авторизація пройшла успішно");
            }
            else
            {
                //Показуємо повідомлення про помилку авторизації
                MessageBox.Show("Невірний логін або пароль");
            }
        }
        // Обробник закривання форми при натисканні на кнопку "Вихід" на вкладці введення логіну та пароля 
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Виходимо із програми
            Application.Exit();
        }
        // Обробник закривання форми при натисканні на кнопку "Вихід" на вкладці введення кількості команд 
        private void btnExit1_Click(object sender, EventArgs e)
        {
            // Виходимо із програми
            Application.Exit();
        }
        // Обробник закривання форми при натисканні на кнопку "Вихід" на вкладці введення назв команд 
        private void btnExit2_Click(object sender, EventArgs e)
        {
            // Виходимо із програми
            Application.Exit();
        }
        // Обробник закривання форми при натисканні на кнопку "Вихід" на вкладці виведення списку турів
        private void btnExit3_Click(object sender, EventArgs e)
        {
            // Виходимо із програми
            Application.Exit();
        }

        // Обробник натискання на кнопку введення кількості команд, визов Input діалогу з класу Input.cs  
        private void size_array_team_Click(object sender, EventArgs e)
        {
            string result = InputDialog.Show("Введення кількості команд", "Кількість команд:");
            int intValue;
            // Перевірка на те, що введено ціле число
            if (int.TryParse(result, out intValue))
            {
                // Перевірка на те, що введена парна кількість команд
                if (intValue % 2 != 0)
                {
                    MessageBox.Show("Кількість команд має бути парною! Спробуйте ще раз:");
                }
                else
                {
                    // Відновити вкладку в TabControl
                    tabControl1.TabPages.Insert(index_tab2 - 1, tabPage2);
                    // Перемикаємось на нову вкладку
                    tabControl1.SelectedTab = tabPage2;
                    index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
                    tabControl1.TabPages.Remove(tabPage1);
                    MessageBox.Show("Кількість команд:" + result);
                    count_team = intValue;
                    count_team_table = intValue;
                }
            }
            else
            {
                MessageBox.Show("Введено не ціле число");
            }
        }
        // Обробник натискання на кнопку введення назв команд, визов Input діалогу з класу Input.cs 
        private void button_add_team_Click(object sender, EventArgs e)
        {
            if (count_team > 0)
            {
                string team = InputDialog.Show("Введіть назву команди", string.Format("Команда №{0}", count_i_team));
                // Перевірка що введено значення
                if (!string.IsNullOrEmpty(team))
                {
                    // Додавання значення в listBox_team
                    teams.Add(team);
                    listBox_team.DataSource = null;
                    listBox_team.DataSource = teams;
                    count_i_team++;
                    count_team--;
                    if (count_team > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Введені всі команди");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введені всі команди");

            }

        }
        // Обробник натискання на кнопку видалення команд, визов Input діалогу з класу Input.cs 
        private void button_dell_team_Click(object sender, EventArgs e)
        {
            string name = InputDialog.Show("Введіть назву команди для видалення", "Видалення команди");
            // Перевірка що введено значення
            if (!string.IsNullOrEmpty(name))
            {
                if (teams.Contains(name))
                {
                    // Видалення значення з listBox_team
                    teams.Remove(name);
                    listBox_team.DataSource = null;
                    listBox_team.DataSource = teams;
                    count_team++;
                    count_i_team--;
                    MessageBox.Show("Команда видалена.", "Видалення команди");
                }
                else
                {
                    MessageBox.Show("Команда не знайдена.", "Видалення команди");
                }
            }
        }
        // Обробник натискання на кнопку створення списку турів
        private void button_create_Click(object sender, EventArgs e)
        {
            if (count_team == 0)
            {
                // Відновити вкладку в TabControl
                tabControl1.TabPages.Insert(index_tab3 - 1, tabPage3);
                // Перемикаємось на нову вкладку
                tabControl1.SelectedTab = tabPage3;
                index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
                tabControl1.TabPages.Remove(tabPage2);
                //
                //
                label1.Text = "\nРозклад турів:\n";

                for (int i = 1; i <= count_team_table - 1; i++)
                {
                    label1.Text += string.Format("Тур {0}:\n", i);

                    for (int j = 0; j < count_team_table / 2; j++)
                    {
                        label1.Text += string.Format("{0} - {1}\n", teams[j], teams[count_team_table - j - 1]);
                    }

                    teams.Insert(1, teams[count_team_table - 1]);
                    teams.RemoveAt(count_team_table);
                }
            }


            else
            {
                MessageBox.Show("Введено не всі команди, створення турів неможливе");
            }
        }


    }

}