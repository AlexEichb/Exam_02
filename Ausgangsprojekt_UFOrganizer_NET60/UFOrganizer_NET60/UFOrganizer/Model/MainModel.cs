using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFOrganizer.Model
{
    public class MainModel
    {
        #region Declaration
        // Members
        string _filepath;
        char _delimiter;
        Thread _fileThread;
        bool _readingFileIsRequested;
        List<ListObject> _listOfCurrentPage;
        IList<IUfoReportListViewObject> _currentReports;

        // Events
        public event EventHandler ModelChanged;

        // Properties
        public List<ListObject> ListOfCurrentPage { get { return _listOfCurrentPage; } }
        public IList<IUfoReportListViewObject> ListOfCurrentReports { get { return _currentReports; } }
        #endregion

        #region Init
        // ctor
        public MainModel()
        {
            // Init
            _readingFileIsRequested = false;
            _listOfCurrentPage = new List<ListObject>();
            //_fileThread = new Thread(new ThreadStart(() =>
            //{
            //    try
            //    {
            //        using (StreamReader streamreader = new StreamReader(_filepath))
            //        {
            //            if (_readingFileIsRequested)
            //            {

            //            }
                        
            //        }

            //    }
            //    catch (Exception e) { };
                
            //}));

            // Subscribe to events
        }

        #endregion

        #region Events


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

        public void OpenFile()
        {
            _filepath = SelectPath();
            _fileThread.Start();
        }

        public List<ListObject> ReadFile(int index)
        {
           if (_filepath == "") { _filepath = SelectPath(); }

           _listOfCurrentPage.Clear();
            try
            {
                using (StreamReader streamreader = new StreamReader(_filepath))
                {
                    bool firstLine = true;
                    int rowIndex = 0;

                    while (!streamreader.EndOfStream)
                    {
                        if (firstLine == false)
                        {
                            string line = streamreader.ReadLine();
                            if(rowIndex == index)
                            {
                                string[] values = line.Split(',');
                                ListObject listObject = new ListObject(values[1], DateTime.Parse(values[3]), values[0]);
                                _listOfCurrentPage.Add(listObject);
                                
                                if((rowIndex+20) == index)
                                {
                                    break;
                                }
                            }
                            rowIndex++;
                        }
                        firstLine = false;
                    }
                    return _listOfCurrentPage;
                }
            }
            catch (Exception e) { MessageBox.Show("Something went wrong while reading data", "Error", 0, MessageBoxIcon.Error); };
            return null;
        }

       
    }
        #endregion
    }
