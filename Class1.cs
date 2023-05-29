using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recc
{
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    class WarningMessageBox : Form
    {
        private const int FormWidth = 1000;
        private const int FormHeight = 250;
        private new const int Padding = 50;
        private const int ButtonWidth = 100;
        private const int ButtonHeight = 30;
        public WarningMessageBox(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        private Label lblMessage;

        private void InitializeComponent()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Width = FormWidth;
            Height = FormHeight;
            BackColor = Color.WhiteSmoke;

            lblMessage = new Label
            {
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Red,
                AutoSize = true,
                Location = new Point(Padding, Padding),
                UseCompatibleTextRendering = true,
               
            };

            var btnOK = new Button
            {
                Text = "OK",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(255, 0, 123, 255),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(100, 30),
                Location = new Point(Width - 100 - Padding, Height - 30 - Padding)
            };
            btnOK.Click += (sender, e) => Close();

            Controls.Add(lblMessage);
            Controls.Add(btnOK);
        }
       

    }
   

}
 

