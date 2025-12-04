using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class SourceCodeForm : Form
    {
        public SourceCodeForm()
        {
            InitializeComponent();
        }

        // Trong file SourceCodeForm.cs
        public SourceCodeForm(string htmlSource)
        {
            InitializeComponent();
            this.Text = "Mã nguồn HTML";
            txtSourceCode.Text = htmlSource;
            txtSourceCode.ReadOnly = true; // Chỉ cho phép xem
        }
    }
}
