using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_OOP_WINF
{
    public static class InputDialog
    {
        public static string Show(string caption, string prompt)
        {
            // Створення нової форми
            Form promptForm = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            // Додавання Label TextBox та Button
            Label promptLabel = new Label()
            {
                Left = 50,
                Top = 20,
                Text = prompt
            };
            TextBox textBox = new TextBox()
            {
                Left = 50,
                Top = 50,
                Width = 400
            };
            Button confirmButton = new Button()
            {
                Text = "OK",
                Left = 350,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.OK
            };
            // Створення обробників та логіки визову для форми.
            confirmButton.Click += (sender, e) => promptForm.Close();
            promptForm.Controls.Add(promptLabel);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmButton);
            promptForm.AcceptButton = confirmButton;
            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
