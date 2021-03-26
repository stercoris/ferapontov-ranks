﻿using RanksClient;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using User = RanksApi.IGetGroupGQL.Response.GroupSelection.UserSelection;


namespace Ranks.ViewModels
{
    class UserViewModel : ReactiveObject, IDisposable
    {
        [Reactive] public User User { get; set; }
        [Reactive] public GroupsAndUsersViewModel groupsvm { get; set; }
        [Reactive] public ImageSource Picture { get; set; }
        public ICommand Select
        { get => ReactiveCommand.Create(() => groupsvm.CurrentlyEditableObject = this); }
        public UserViewModel(GroupsAndUsersViewModel groupsvm, User user)
        {
            this.User = user;
            this.groupsvm = groupsvm;
            LoadImage();
        }

        async private Task LoadImage()
        {
            var pic = (await RanksApi.IGetUserImageGQL.SendQueryAsync(API.Client, new RanksApi.IGetUserImageGQL.Variables { id = this.User.id })).Data.User.picture;
            this.Picture = Services.ImageConverter.toImage(pic, 250, 150);
        }

        public void Dispose()
        {
            if (this.Picture != null)
                this.Picture = null;
        }
    }
}
