using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test_Svel
{
    public partial class Solver: Form
    {
        public Solver()
        {
            
        }

        public string[] lines;
        public string[] updLines;
        public string file;

        public void Search(Form1 form1)
        {
            
            form1.listBox.Items.Clear();

            var result = new List<string>();
            var temp =
                result.Cast<string>().
                GroupBy(s => s).
                OrderByDescending(s => s.Count()).
                ThenBy(s => s.Key);

            if (lines != null)
            {
                foreach (string line in lines)
                {
                    if (form1.textBoxSearch.Text.Length > 2)
                    {
                        form1.listBox.Items.Remove(line);
                        if (line.Contains(form1.textBoxSearch.Text))
                        {
                            result.Add(line);
                        }
                    }
                    else
                    {
                        form1.listBox.Items.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Добавьте словарь в базу!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            foreach (var line in temp)
            {
                if (line.Count() > 2)
                {
                    form1.listBox.Items.Add(line.Key);
                }

            }
        }

        public void CreateDict(Form1 form1)
        {
            if (form1.fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            file = form1.fileDialog.FileName;
            lines = File.ReadAllLines(file);

            MessageBox.Show(
                "Словарь успешно создан",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void DeleteDict(Form1 form1)
        {
            form1.textBoxSearch.Text = "";
            form1.listBox.Items.Clear();
            lines = null;

            MessageBox.Show(
                "Словарь успешно очищен",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void UpdateDict(Form1 form1)
        {
            if (form1.fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            file = form1.fileDialog.FileName;
            updLines = File.ReadAllLines(file);
            lines = lines.Concat(updLines).ToArray();

            MessageBox.Show(
                "Словарь успешно дополнен",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void DelSpace(Form1 form1)
        {
            if (form1.textBoxSearch.Text.Contains(" "))
            {
                if (form1.textBoxSearch.Text.Contains(".") || form1.textBoxSearch.Text.Contains(","))
                {
                    form1.textBoxSearch.Text = form1.textBoxSearch.Text.Replace(" ", "");
                    form1.textBoxSearch.SelectionStart = form1.textBoxSearch.Text.Length;
                }
            }
        }

        public void ListBoxChange(Form1 form1)
        {
            if (form1.listBox.SelectedItem != null)
            {
                form1.textBoxSearch.Text = form1.listBox.SelectedItem.ToString() + " ";
            }
            form1.textBoxSearch.Focus();
            form1.textBoxSearch.DeselectAll();
            form1.textBoxSearch.SelectionStart = form1.textBoxSearch.Text.Length;
        }

    }
}
