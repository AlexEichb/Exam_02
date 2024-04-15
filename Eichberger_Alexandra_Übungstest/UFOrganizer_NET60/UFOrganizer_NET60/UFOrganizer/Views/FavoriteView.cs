using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UFOrganizer.Views
{
    public partial class FavoriteView : Form
    {
        #region Declaration
        public event EventHandler DeleteAllFavorites;
        public event EventHandler SaveFavorites;
        public event EventHandler LoadFavorites;
        #endregion

        #region Init
        public FavoriteView()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllFavorites?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFavorites?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadFavorites?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Methods
        public void UpdateList(List<ListObject> items)
        {
            favoriteListBox.Items.Clear();

            foreach (var item in items)
            {
                favoriteListBox.Items.Add(item);
            }
        }
         
        #endregion
    }
}
