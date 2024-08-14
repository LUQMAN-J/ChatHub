using ChatHub.Models;
using ChatHub.ViewControls.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.ViewModels
{
    public partial class FindStoreViewModel : AppViewModelBase
    {
        [ObservableProperty]
        public IList<Store> stores;
        [ObservableProperty]
        public bool disableBackGround;

        public FindStoreViewModel(IApiService appApiService) : base(appApiService)
        {
        }
        [RelayCommand]
        public async Task getStorePopup()
        {
            this.Stores = await _appApiService.getStores();
            var sheet = new OnBottomSheet();
            DisableBackGround = true;
            sheet.BindingContext = this;
            await sheet.ShowAsync();

        }


    }
}
