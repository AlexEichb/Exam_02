using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UFOrganizer;

namespace MvpPeopleAdmin
{
    public class CSVPersistor
    {
        #region Declaration
        private char _delimiter; // Trennzeichen wie ";" , "," , ":"
        #endregion

        #region Init
        public CSVPersistor(char delimiter)
        {
            _delimiter = delimiter;
        }
        #endregion

        #region Methods
        // Bsp für Pfad definieren in "PersonListModel" unter SelectPath()
        public List<ListObject> LoadData(string filepath)
        {
            try
            {
                using(StreamReader streamreader = new StreamReader(filepath))
                {
                    List<ListObject> loadedPersons = new List<ListObject>();
                    bool firstLine = true;

                    while (!streamreader.EndOfStream)
                    {
                        string line = streamreader.ReadLine();
                        if (firstLine == false)
                        {
                            string[] values = line.Split(';');
                            ListObject person = new ListObject(values[0], DateTime.ToString(values[1]), values[2]);
                            loadedPersons.Add(person);
                        }
                        firstLine = false;
                    }
                    return loadedPersons;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't read data", "Error", 0, MessageBoxIcon.Error);
            }

            return null;
        }

        public void SaveData(List<ListObject> listOfObjects, string filepath)
        {
            try
            {
                using (StreamWriter streamwriter = new StreamWriter(filepath, false))
                {
                    // Header
                    streamwriter.WriteLine("Summary;City;Date");

                    for (int i = 0; i < listOfObjects.Count; i++)
                    {
                        streamwriter.WriteLine(listOfObjects[i].Summary + ";" + listOfObjects[i].City + ";" + listOfObjects[i].DateTime.ToString()); ; ;
                    }

                    streamwriter.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Couldn't save data", "Error", 0, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
