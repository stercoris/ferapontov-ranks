﻿using Order.DataAccess.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace Order.WPF.ViewModels
{
    class GroupViewModel : ReactiveObject
    {
        [Reactive] public Group Group { get; set; }

        // Каллбек для фетча пользователей группы
        [Reactive] public ICommand ShowUsersCommand { get; set; }
        // Каллбек для перемещения объекта в режим редактирования
        public ICommand EditCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand DeleteGroupCommand { get; set; }

        public GroupViewModel(
            Group group,
            ICommand groupSelectCommand,
            ICommand groupEditCommand,
            ICommand addStudentCommand,
            ICommand deleteGroupCommand
        )
        {
            this.Group = group;
            EditCommand = groupEditCommand;
            ShowUsersCommand = groupSelectCommand;
            AddStudentCommand = addStudentCommand;
            DeleteGroupCommand = deleteGroupCommand;
        }
    }
}