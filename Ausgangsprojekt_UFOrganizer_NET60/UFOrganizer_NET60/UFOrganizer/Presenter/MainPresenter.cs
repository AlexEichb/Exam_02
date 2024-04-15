using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFOrganizer.Model;
using UFOrganizer.Presenter;
using UFOrganizer.View;

namespace UFOrganizer
{
    public class MainPresenter
    {
        #region Declaration
        // Members
        Form1 _mainView;
        MainModel _mainModel;
        FavoritePresenter _favoritePresenter;
        int _lastRowIndex;
        int _pageIndex;

        // Events
        public event EventHandler<List<ListObject>> SaveReportsRequested;
        #endregion

        #region Init
        // ctor

        public MainPresenter()
        {
            // Init
            _mainView = new Form1();
            _mainModel = new MainModel();
            _favoritePresenter = new FavoritePresenter();
            _lastRowIndex = 0;
            _pageIndex = 0;

            // Subscribe to events
            _mainView.OpenFileRequested += OnOpenFileRequested;
            _mainView.OpenFavoritesRequested += OnOpenFavoritesRequested;
            _mainView.PreviousPageRequested += OnPreviousPageRequested;
            _mainView.NextPageRequested += OnNextPageRequested;
            _mainView.SaveReportsRequested += OnSaveReportsRequested;
            _mainModel.ModelChanged += OnModelChanged;
        }

        private void OnModelChanged(object? sender, EventArgs e)
        {
            _mainView.UpdateReports(_mainModel.ListOfCurrentPage,_pageIndex);
        }
        #endregion

        #region Events
        private void OnSaveReportsRequested(object? sender, IList<IUfoReportListViewObject> e)
        {
            List<ListObject> listOfReports = _mainView.SelectedRows();
            SaveReportsRequested?.Invoke(this, listOfReports);
        }

        private void OnNextPageRequested(object? sender, EventArgs e)
        {
            _mainModel.ReadFile(_lastRowIndex+20);
            _pageIndex++;
        }

        private void OnPreviousPageRequested(object? sender, EventArgs e)
        {
            _mainModel.ReadFile(_lastRowIndex-20);
            _pageIndex--;
        }

        private void OnOpenFavoritesRequested(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnOpenFileRequested(object? sender, EventArgs e)
        {
            _mainModel.OpenFile();
            _mainModel.ReadFile(_lastRowIndex);
        }

        #endregion


        #region Methods
        public void Run()
        {
            _mainView.Show();
            _favoritePresenter.Start();
            Application.Run();
        }

        
        #endregion

    }
}
