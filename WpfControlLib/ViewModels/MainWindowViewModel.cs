using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WpfControlLib.Infrastructure.Commands;
using WpfControlLib.Models;
using WpfControlLib.Services.Interfaces;
using WpfControlLib.Services;
using WpfControlLib.ViewModels.Base;
// using WpfControlLib.Views.Windows;
using WpfControlLib.Services;
using System.Diagnostics;

namespace WpfControlLib.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        GroupsService groupsService;

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "WpfControlLib--Управление студентами-2";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion
        public IEnumerable<Group> Groups => groupsService.GetAll();

        #region SelectedGroup : Group - Выбранная группа студентов

        /// <summary>Выбранная группа студентов</summary>
        private Group _SelectedGroup;

        /// <summary>Выбранная группа студентов</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                // Debug.WriteLine($"_SelectedGroup.Name : {_SelectedGroup.Name}");
                Set(ref _SelectedGroup, value);
            }

        }

        #endregion

        #region Команды
        #region  Command TestCommand2 - Тестовая команда	
        private LambdaCommand testCommand2;

        public ICommand TestCommand2
        {
            get
            {
                if (testCommand2 == null)
                {
                    testCommand2 = new LambdaCommand(Test);
                }
                return testCommand2;
            }
        }

        private void Test(object commandParameter)
        {
        }
        #endregion

        #region Command TestCommand - Тестовая команда
        /// <summary>Тестовая команда</summary>
        private ICommand _TestCommand;

        /// <summary>Тестовая команда</summary>
        public ICommand TestCommand()
        {
            get
            {
                if (_TestCommand == null)
                {
                    _TestCommand = new LambdaCommand(OnTestCommandExecuted, CanTestCommandExecute);
                }
                return _TestCommand;
            }
        }

        /// <summary>Проверка возможности выполнения - Тестовая команда</summary>
        private bool CanTestCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Тестовая команда</summary>
        private void OnTestCommandExecuted(object p)
        {
            //var value = _UserDialog.GetStringValue("Введите строку", "123", "Значение по умолчанию");
            //_UserDialog.ShowInformation($"Введено: {value}", "123");

            Debug.WriteLine("MainWindowViewModel--OnTestCommandExecuted(object p)");
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            groupsService = new GroupsService();
        }
    }
}
