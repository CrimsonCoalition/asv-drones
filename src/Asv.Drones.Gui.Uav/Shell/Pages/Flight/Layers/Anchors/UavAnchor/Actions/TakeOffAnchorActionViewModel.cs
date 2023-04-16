﻿using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Asv.Cfg;
using Asv.Drones.Gui.Core;
using Asv.Drones.Uav;
using Asv.Mavlink;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using FluentAvalonia.UI.Controls;
using Material.Icons;
using ReactiveUI;

namespace Asv.Drones.Gui.Uav
{
    public class TakeOffAnchorActionViewModel : UavActionActionBase
    {
        private readonly ILogService _log;
        private readonly IConfiguration _cfg;
        private readonly ILocalizationService _loc;
        
        public TakeOffAnchorActionViewModel(IVehicleClient vehicle, IMap map, ILogService log, IConfiguration cfg, ILocalizationService loc) : base(vehicle, map, log)
        {
            _log = log;
            _cfg = cfg;
            _loc = loc;
            
            Title = "TakeOff";
            Icon = MaterialIconKind.ArrowUpBoldHexagonOutline;
            
            Command = ReactiveCommand.CreateFromTask(ExecuteImpl, CanExecute);
            Vehicle.Position.IsArmed.ObserveOn(RxApp.MainThreadScheduler).Select(_ => !_).Subscribe(CanExecute).DisposeWith(Disposable);
        }

        protected override async Task ExecuteImpl(CancellationToken cancel)
        {
            var selectedItem = Map.SelectedItem;
            
            Map.SelectedItem = null;
            
            var dialog = new ContentDialog()
            {
                Title = RS.TakeOffAnchorActionViewModel_Title,
                PrimaryButtonText = RS.TakeOffAnchorActionViewModel_DialogPrimaryButton,
                IsSecondaryButtonEnabled = true,
                SecondaryButtonText = RS.TakeOffAnchorActionViewModel_DialogSecondaryButton
            };
            
            var viewModel = new TakeOffViewModel(_cfg, _loc);
            viewModel.ApplyDialog(dialog);
            dialog.Content = viewModel;
            
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var altInMeters = _loc.Altitude.ConvertToSi(viewModel.Altitude);
                _log.Info(LogName, string.Format(RS.TakeOffAnchorActionViewModel_LogMessage,_loc.Altitude.FromSiToStringWithUnits(altInMeters), Vehicle.Name.Value));
                await Vehicle.TakeOff(altInMeters, cancel);
            }

            Map.SelectedItem = selectedItem;
        }
    }
}