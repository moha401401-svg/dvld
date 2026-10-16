
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public class InfoSelectorControl : UserControl
    {
        private SearchGridControl searchGrid;
        private UserControl infoCard;

        private string infoColumnName = "";

        private Dictionary<string, string> searchColumns =
            new Dictionary<string, string>();


        public string InfoColumnName
        {
            get
            {
                return infoColumnName;
            }

            set
            {
                infoColumnName =
                    value;
            }
        }


        public DataGridView dgv
        {
            get
            {
                return searchGrid.Grid;
            }
        }


        public Dictionary<string, string> SearchColumns
        {
            get
            {
                return searchColumns;
            }

            set
            {
                searchColumns =
                    value ??
                    new Dictionary<string, string>();
            }
        }


        public int? SelectedId
        {
            get;
            private set;
        }


        public UserControl InfoCard
        {
            get
            {
                return infoCard;
            }

            set
            {
                if (infoCard != null)
                {
                    Controls.Remove(
                        infoCard);
                }

                infoCard =
                    value;

                if (infoCard == null)
                    return;

                infoCard.Dock =
                    DockStyle.Fill;

                infoCard.Margin =
                    new Padding(10);

                Controls.Add(
                    infoCard);

                infoCard.BringToFront();
            }
        }


        public Action<int> LoadSelectedItem
        {
            get;
            set;
        }


        public InfoSelectorControl()
        {
            InitializeControl();

            InitializeSearchGrid();
        }


        private void InitializeControl()
        {
            Dock =
                DockStyle.Fill;

            BackColor =
                Presentation.UI.Theme.AppBackground;
        }


        private void InitializeSearchGrid()
        {
            searchGrid =
                new SearchGridControl();

            searchGrid.Dock =
                DockStyle.Left;

            searchGrid.Width =
                620;

            searchGrid.RowClicked +=
                SearchGrid_RowClicked;

            Controls.Add(
                searchGrid);
        }


        private void SearchGrid_RowClicked(
            DataRow row)
        {
            if (row == null)
                return;


            if (string.IsNullOrWhiteSpace(
                    InfoColumnName))
            {
                return;
            }


            if (!row.Table.Columns.Contains(
                    InfoColumnName))
            {
                return;
            }


            object value =
                row[InfoColumnName];


            if (value == null ||
                value == DBNull.Value)
            {
                SelectedId =
                    null;

                return;
            }


            if (!int.TryParse(
                    value.ToString(),
                    out int id))
            {
                SelectedId =
                    null;

                return;
            }


            SelectedId =
                id;


            LoadSelectedItem?.Invoke(
                id);
        }


        public void LoadData(
            DataTable data)
        {
            searchGrid.LoadData(
                data,
                SearchColumns);
        }
    }
}

