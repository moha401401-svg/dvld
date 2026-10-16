using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLD.Presentation.UI;

namespace DVLD.Controls
{
    public class BooleanSearchOption
    {
        public string Text { get; set; }

        public bool Value { get; set; }

        public BooleanSearchOption(string text, bool value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
    public class SearchGridControl : UserControl
    {
        private ComboBox cmbBoolean;
        private DataTable sourceTable;
        private DataView sourceView;

        private RoundedTextBox txtSearch;
        private ComboBox cmbSearchBy;
        private DataGridView dgv;


        private Dictionary<string, string> searchColumns;


        public event Action<DataRow> RowDoubleClicked;
        public event Action<DataRow> RowClicked;

        public SearchGridControl()
        {
            InitializeUI();
        }



        public DataGridView Grid
        {
            get
            {
                return dgv;
            }
        }

        public void SetBooleanOptions( List<BooleanSearchOption> options)
        {
            cmbBoolean.Items.Clear();

            foreach (var item in options)
            {
                cmbBoolean.Items.Add(item);
            }
        }
        private void InitializeUI()
        {
            Size =
                new Size(800, 450);


            txtSearch =
                new RoundedTextBox();

            txtSearch.Location =
                new Point(10, 10);

            txtSearch.Width =
                250;

            txtSearch.Placeholder =
                "Search...";


            txtSearch.TextChanged +=
                TxtSearch_TextChanged;


            Controls.Add(txtSearch);

            cmbBoolean = new ComboBox();

            cmbBoolean.Location =
                txtSearch.Location;

            cmbBoolean.Width =
                txtSearch.Width;

            cmbBoolean.DropDownStyle =
                ComboBoxStyle.DropDownList;


            cmbBoolean.Visible = false;


            cmbBoolean.SelectedIndexChanged +=
                CmbBoolean_SelectedIndexChanged;


            Controls.Add(cmbBoolean);

            cmbSearchBy =
                new ComboBox();


            cmbSearchBy.Location =
                new Point(280, 10);


            cmbSearchBy.Width =
                170;


            cmbSearchBy.DropDownStyle =
                ComboBoxStyle.DropDownList;


            cmbSearchBy.SelectedIndexChanged +=
                CmbSearchBy_SelectedIndexChanged;


            Controls.Add(cmbSearchBy);




            dgv =
                new DataGridView();


            dgv.Location =
                new Point(10, 60);

            dgv.Size =
            new Size(
                Width - 20,
                Height - 70);

            dgv.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgv.ScrollBars =
                ScrollBars.Both;


            dgv.ReadOnly =
                true;


            dgv.AllowUserToAddRows =
                false;


            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;


            dgv.BackgroundColor =
                Color.White;


            dgv.BorderStyle =
                BorderStyle.None;


            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;



            dgv.DoubleClick +=
                Dgv_DoubleClick;

            dgv.CellClick +=
                Dgv_CellClick;

            Controls.Add(dgv);
        }


        private void CmbSearchBy_SelectedIndexChanged(
          object sender,
          EventArgs e)
        {
            if (sourceTable == null)
                return;

            if (!searchColumns.ContainsKey(cmbSearchBy.Text))
                return;

            string column =
                searchColumns[cmbSearchBy.Text];

            if (!sourceTable.Columns.Contains(column))
                return;

            DataColumn col =
                sourceTable.Columns[column];

            if (col == null)
                return;

            if (col.DataType == typeof(bool))
            {
                txtSearch.Visible = false;
                cmbBoolean.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                cmbBoolean.Visible = false;
            }
        }
        private void CmbBoolean_SelectedIndexChanged( object sender, EventArgs e)
        {
            BooleanSearchOption option =
                cmbBoolean.SelectedItem
                as BooleanSearchOption;


            string column =
                searchColumns[cmbSearchBy.Text];


            sourceView.RowFilter =
                $"[{column}] = {option.Value}";
        }
        public void LoadData(
            DataTable data,
            Dictionary<string, string> columns)
        {

            sourceTable =
                data;


            sourceView =
                sourceTable.DefaultView;


            searchColumns =
                columns;


            dgv.DataSource =
                sourceView;


            LoadSearchTypes();
        }





        private void LoadSearchTypes()
        {
            cmbSearchBy.Items.Clear();


            foreach (var item in searchColumns)
            {
                cmbSearchBy.Items.Add(
                    item.Key);
            }


            if (cmbSearchBy.Items.Count > 0)
            {
                cmbSearchBy.SelectedIndex = 0;
            }
        }





        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            ApplyFilter();
        }





      
        






        private void ApplyFilter()
        {

            if (sourceView == null)
                return;


            if (searchColumns == null)
                return;


            if (cmbSearchBy.SelectedIndex == -1)
                return;



            string text =
                txtSearch.Text.Trim();



            if (string.IsNullOrEmpty(text))
            {
                sourceView.RowFilter = "";
                return;
            }



            string column =
                searchColumns[cmbSearchBy.Text];



            text =
                text.Replace("'", "''");



            sourceView.RowFilter =
                $"CONVERT([{column}], System.String) LIKE '%{text}%'";
            dgv.DataSource = null;
            dgv.DataSource = sourceView;
        }







        private void Dgv_DoubleClick(
            object sender,
            EventArgs e)
        {

            if (dgv.CurrentRow == null)
                return;



            DataRowView row =
                dgv.CurrentRow.DataBoundItem
                as DataRowView;



            if (row != null)
            {
                RowDoubleClicked?.Invoke(
                    row.Row);
            }
        }
        private void Dgv_CellClick( object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            DataRowView row =
                dgv.Rows[e.RowIndex]
                .DataBoundItem
                as DataRowView;


            if (row != null)
            {
                RowClicked?.Invoke(
                    row.Row);
            }
        }
    }
}