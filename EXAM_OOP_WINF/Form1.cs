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
        // ��������� ������ ������
        private List<string> teams = new List<string>();
        // ��������� ������ Tray
        private NotifyIcon trayIcon;
        // ���� ��� ������ ������� PageTab, ��� �������� �������� �� ��������� ��
        private int index_tab1;
        private int index_tab2;
        private int index_tab3;
        // ���� ��������� ������� ������ ��� ����� �������
        private int count_i_team = 1;
        private int count_team;
        private int count_team_table;
        public Form1()
        {
            InitializeComponent();
            // ����������� ��� ����� ��������� �� ���� TabPage �� �������� �� �������
            index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
            tabControl1.TabPages.Remove(tabPage1);
            index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
            tabControl1.TabPages.Remove(tabPage2);
            index_tab3 = tabControl1.TabPages.IndexOf(tabPage3);
            tabControl1.TabPages.Remove(tabPage3);
            // ��������� ������ � tray
            trayIcon = new NotifyIcon();
            trayIcon.Text = "My App";
            trayIcon.Icon = new Icon("C:\\Users\\Admin\\source\\repos\\EXAM_OOP_WINF\\EXAM_OOP_WINF\\Anonymous_emblem.svg.ico");
            trayIcon.Visible = true;

            listBox_team.DataSource = teams;
            // ������ �������� ��� ��������� ���������� �� ������ � ���.
            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            // ������ �������� ��� ���������� �� ������ � ���.
            trayIcon.MouseClick += TrayIcon_MouseClick;
        }

        // �������� ��� ��������� ���������� �� ������ � ���
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            // �������� ������� ���� ��������
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        // �������� ��� ���������� �� ������ � ���
        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // ��������� �������� � ��� ���������� �� ������ ���� ��� ���� �� ������ �������
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("�������� ��� ���� ���");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("�������� ��� ���� ���");
            }
        }
        // �������� ���������� �����
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            this.Hide();
        }
        // �������� ���������� �����
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ����� � �������
            Application.Exit();
        }
        // �������� ���������� �� ������ "����"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ����������, �� ������� ���� �� ������
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("������ ���� �� ������");
                return;
            }

            // ���������� ���� �� ������ �� ����������
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                TabPage selectedTab = tabControl1.SelectedTab;
                // ��������� ������� �������
                tabControl1.TabPages.Remove(selectedTab);
                // ³������� ������� � TabControl
                tabControl1.TabPages.Insert(index_tab1 - 1, tabPage1);
                // ������������ �� ���� �������
                tabControl1.SelectedTab = tabPage1;
                // �������� ����������� ��� ������ �����������
                MessageBox.Show("����������� ������� ������");
            }
            else
            {
                //�������� ����������� ��� ������� �����������
                MessageBox.Show("������� ���� ��� ������");
            }
        }
        // �������� ���������� ����� ��� ��������� �� ������ "�����" �� ������� �������� ����� �� ������ 
        private void btnExit_Click(object sender, EventArgs e)
        {
            //�������� �� ��������
            Application.Exit();
        }
        // �������� ���������� ����� ��� ��������� �� ������ "�����" �� ������� �������� ������� ������ 
        private void btnExit1_Click(object sender, EventArgs e)
        {
            // �������� �� ��������
            Application.Exit();
        }
        // �������� ���������� ����� ��� ��������� �� ������ "�����" �� ������� �������� ���� ������ 
        private void btnExit2_Click(object sender, EventArgs e)
        {
            // �������� �� ��������
            Application.Exit();
        }
        // �������� ���������� ����� ��� ��������� �� ������ "�����" �� ������� ��������� ������ ����
        private void btnExit3_Click(object sender, EventArgs e)
        {
            // �������� �� ��������
            Application.Exit();
        }

        // �������� ���������� �� ������ �������� ������� ������, ����� Input ������ � ����� Input.cs  
        private void size_array_team_Click(object sender, EventArgs e)
        {
            string result = InputDialog.Show("�������� ������� ������", "ʳ������ ������:");
            int intValue;
            // �������� �� ��, �� ������� ���� �����
            if (int.TryParse(result, out intValue))
            {
                // �������� �� ��, �� ������� ����� ������� ������
                if (intValue % 2 != 0)
                {
                    MessageBox.Show("ʳ������ ������ �� ���� ������! ��������� �� ���:");
                }
                else
                {
                    // ³������� ������� � TabControl
                    tabControl1.TabPages.Insert(index_tab2 - 1, tabPage2);
                    // ������������ �� ���� �������
                    tabControl1.SelectedTab = tabPage2;
                    index_tab1 = tabControl1.TabPages.IndexOf(tabPage1);
                    tabControl1.TabPages.Remove(tabPage1);
                    MessageBox.Show("ʳ������ ������:" + result);
                    count_team = intValue;
                    count_team_table = intValue;
                }
            }
            else
            {
                MessageBox.Show("������� �� ���� �����");
            }
        }
        // �������� ���������� �� ������ �������� ���� ������, ����� Input ������ � ����� Input.cs 
        private void button_add_team_Click(object sender, EventArgs e)
        {
            if (count_team > 0)
            {
                string team = InputDialog.Show("������ ����� �������", string.Format("������� �{0}", count_i_team));
                // �������� �� ������� ��������
                if (!string.IsNullOrEmpty(team))
                {
                    // ��������� �������� � listBox_team
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
                        MessageBox.Show("������ �� �������");
                    }
                }
            }
            else
            {
                MessageBox.Show("������ �� �������");

            }

        }
        // �������� ���������� �� ������ ��������� ������, ����� Input ������ � ����� Input.cs 
        private void button_dell_team_Click(object sender, EventArgs e)
        {
            string name = InputDialog.Show("������ ����� ������� ��� ���������", "��������� �������");
            // �������� �� ������� ��������
            if (!string.IsNullOrEmpty(name))
            {
                if (teams.Contains(name))
                {
                    // ��������� �������� � listBox_team
                    teams.Remove(name);
                    listBox_team.DataSource = null;
                    listBox_team.DataSource = teams;
                    count_team++;
                    count_i_team--;
                    MessageBox.Show("������� ��������.", "��������� �������");
                }
                else
                {
                    MessageBox.Show("������� �� ��������.", "��������� �������");
                }
            }
        }
        // �������� ���������� �� ������ ��������� ������ ����
        private void button_create_Click(object sender, EventArgs e)
        {
            if (count_team == 0)
            {
                // ³������� ������� � TabControl
                tabControl1.TabPages.Insert(index_tab3 - 1, tabPage3);
                // ������������ �� ���� �������
                tabControl1.SelectedTab = tabPage3;
                index_tab2 = tabControl1.TabPages.IndexOf(tabPage2);
                tabControl1.TabPages.Remove(tabPage2);
                //
                //
                label1.Text = "\n������� ����:\n";

                for (int i = 1; i <= count_team_table - 1; i++)
                {
                    label1.Text += string.Format("��� {0}:\n", i);

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
                MessageBox.Show("������� �� �� �������, ��������� ���� ���������");
            }
        }


    }

}