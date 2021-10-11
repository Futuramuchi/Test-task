using LettersAnalyzer.Core;
using LettersAnalyzer.Helper;
using LettersAnalyzer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace LettersAnalyzer.ViewModel
{
    public class TextAnalyzerViewModel : BaseViewModel
    {
        public DataModel Data { get; set; }
        public ObservableCollection<DataFullModel> FullData { get; set; }
        public ICollectionView DataView { get; set; }

        private string _rowsIdentifier { get; set; }
        private bool _isButtonEnbale { get; set; } = false;
        private ICommand _findCurrentText { get; set; }
        private string _incorrectTextBackground { get; set; }

        public TextAnalyzerViewModel()
        {
            FullData = new ObservableCollection<DataFullModel>();
            DataView = CollectionViewSource.GetDefaultView(FullData);
        }

        public string RowsIdentifier
        {
            get => _rowsIdentifier;
            set
            {
                _rowsIdentifier = value;
                OnPropertyChanged("RowsIdentifier");

                IsButtonEnable = _rowsIdentifier.Length > 0 ? true : false;
            }
        }

        public string IncorrectTextBackground
        {
            get => _incorrectTextBackground;
            set
            {
                _incorrectTextBackground = value;
                OnPropertyChanged("IncorrectTextBackground");
            }
        }

        public bool IsButtonEnable
        {
            get => _isButtonEnbale;
            set
            {
                _isButtonEnbale = value;
                OnPropertyChanged("IsButtonEnable");
            }
        }

        public ICommand FindCurrentText
        {
            get
            {
                return _findCurrentText ?? (_findCurrentText = new RelayCommand(async (_) =>
                {
                    FullData.Clear();

                    if (RowsIdentifier.Any(Char.IsLetter))
                    {
                        MessageBox.Show(
                            messageBoxText: "Строка не может содержать буквы",
                            caption: "Уведомление",
                            button: MessageBoxButton.OK,
                            icon: MessageBoxImage.Exclamation);
                    }
                    else
                    {

                        var identifiers = NumbersParser.Parse(RowsIdentifier);

                        if (identifiers.Select(x => x).Any(x => x > 20))
                        {
                            IncorrectTextBackground = "#ACACAC";

                            MessageBox.Show(
                                messageBoxText: "Числа в строке могут варьироваться только от 1 до 20",
                                caption: "Уведомление",
                                button: MessageBoxButton.OK,
                                icon: MessageBoxImage.Exclamation);
                        }

                        for (int i = 0; i < identifiers.Count; i++)
                        {
                            try
                            {
                                #region Request
                                string url = $"https://tmgwebtest.azurewebsites.net/api/textstrings/{identifiers[i]}";

                                HttpClient client = new HttpClient();
                                client.DefaultRequestHeaders.Add("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");

                                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                                var responseContent = await response.Content.ReadAsStringAsync();

                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    Data = JsonConvert.DeserializeObject<DataModel>(responseContent);
                                    FullData.Add(new DataFullModel()
                                    {
                                        TextData = Data
                                    });
                                }
                                #endregion
                            }
                            catch (Exception er)
                            {
                                MessageBox.Show(
                                    messageBoxText: $"{er.Message}",
                                    caption: "Уведомление",
                                    button: MessageBoxButton.OK,
                                    icon: MessageBoxImage.Exclamation);
                            }
                        }

                    }

                    DataView.Refresh();
                }));
            }
        }
    }
}
