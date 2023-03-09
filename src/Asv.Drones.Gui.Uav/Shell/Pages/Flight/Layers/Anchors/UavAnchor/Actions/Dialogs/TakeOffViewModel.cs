﻿
using System.ComponentModel.Composition;
using System.Reactive.Linq;
using Asv.Cfg;
using Asv.Common;
using Asv.Drones.Gui.Core;
using FluentAvalonia.UI.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;

namespace Asv.Drones.Gui.Uav;


public class TakeOffViewModelConfig
{
    public double TakeOffAltitudeMeter { get; set; } = 30;
}

[ExportShellPage(UriString)]
[PartCreationPolicy(CreationPolicy.Shared)]
public class TakeOffViewModel : ViewModelBaseWithValidation
{
    private readonly IConfiguration _cfg;
    private readonly ILocalizationService _loc;
    
    public const string UriString = UavAnchor.BaseUriString + ".actions.takeoff";
    public static readonly Uri Uri = new(UriString);
    private readonly TakeOffViewModelConfig _config;

    public const double MinimumAltitudeMeter = 1;

    [ImportingConstructor]
    public TakeOffViewModel(IConfiguration cfg, ILocalizationService loc) : this()
    {
        _cfg = cfg;
        _loc = loc;
        _config = cfg.Get<TakeOffViewModelConfig>();
        Altitude = _loc.Altitude.FromSIToString(_config.TakeOffAltitudeMeter);

        this.ValidationRule(x => x.Altitude, _=>  _loc.Altitude.IsValid(_), _=>  _loc.Altitude.GetErrorMessage(_) )
            .DisposeItWith(Disposable);
        
        this.ValidationRule(x => x.Altitude, 
                _ => _loc.Altitude.IsValid(_) && _loc.Altitude.ConvertToSI(_) >= MinimumAltitudeMeter, 
                string.Format(RS.TakeOffAnchorActionViewModel_ValidValue, _loc.Altitude.FromSIToString(MinimumAltitudeMeter)))
            .DisposeItWith(Disposable);
    }

    public TakeOffViewModel() : base(Uri)
    {
        
    }
    
    public void ApplyDialog(ContentDialog dialog)
    {
        if (dialog == null) throw new ArgumentNullException(nameof(dialog));
        
        dialog.PrimaryButtonCommand =
            ReactiveCommand.Create(() =>
                {
                    _config.TakeOffAltitudeMeter = _loc.Altitude.ConvertToSI(Altitude);
                    _cfg.Set(_config);
                },
                this.IsValid().Do(_ =>dialog.IsPrimaryButtonEnabled = _)).DisposeItWith(Disposable);
    }

    [Reactive]
    public string Altitude { get; set; }

    public string Units => _loc.Altitude.CurrentUnit.Value.Unit;
}