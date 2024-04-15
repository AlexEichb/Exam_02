using MvpPeopleAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFOrganizer.Views;

namespace UFOrganizer.Presenter
{
    public class FavoritePresenter
    {
        #region Declaration
        // Members
        FavoriteView _favoriteView;
        List<ListObject> _listOfFavorites;
        CSVPersistor _csvPersistor;
        MainPresenter _mainPresenter;

        // Events

        // Properties
        public List<ListObject> FavoriteList { get { return _listOfFavorites; } }

        #endregion

        #region Init
        // ctor
        public FavoritePresenter()
        {
            // Init
            _favoriteView = new FavoriteView();
            _csvPersistor = new CSVPersistor(',');
            _listOfFavorites = new List<ListObject>();
            _mainPresenter = new MainPresenter();

            // Subscribe to events
            _favoriteView.DeleteAllFavorites += OnDeleteAllFavorites;
            _favoriteView.SaveFavorites += OnSaveFavorites;
            _favoriteView.LoadFavorites += OnLoadFavorites;
            _mainPresenter.SaveReportsRequested += OnSaveReportsRequested;
        }

        private void OnSaveReportsRequested(object? sender, List<ListObject> e)
        {
            AddFavorites(e);
        }

        private void OnLoadFavorites(object? sender, EventArgs e)
        {
            string filepath = SelectPath();
            _csvPersistor.LoadData(filepath);
        }

        private void OnSaveFavorites(object? sender, EventArgs e)
        {
            string filepath = SelectPath();
            _csvPersistor.SaveData(_listOfFavorites ,filepath);
        }

        private void OnDeleteAllFavorites(object? sender, EventArgs e)
        {
            _listOfFavorites.Clear();
        }


        #endregion


        #region Methods
        public string SelectPath()
        {
            try
            {
                ;
                OpenFileDialog fileDialog = new OpenFileDialog();

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fileDialog.FileName;
                    return selectedPath;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong.", "Error", 0, MessageBoxIcon.Error);
            }
            return null;
        }

        public void AddFavorites(List<ListObject> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                bool isAlreadyInList = CheckIfEntryIsAlreadyInList(list, i);
                if (isAlreadyInList == false)
                {
                    _listOfFavorites.Add(list[i]);
                    _favoriteView.UpdateList(_listOfFavorites);
                }
                
            }
        }

        private bool CheckIfEntryIsAlreadyInList(List<ListObject> list, int index)
        {

            for(int j = 0; j < _listOfFavorites.Count; j++)
            {
                if (list[index].Summary==_listOfFavorites[j].Summary && list[index].City == _listOfFavorites[j].City 
                    && list[index].DateTime == _listOfFavorites[j].DateTime)
                {
                    return true;
                }
            }
            return false;
        }

        public void Start()
        {
            _favoriteView.Show();
        }
        #endregion
    }
}
