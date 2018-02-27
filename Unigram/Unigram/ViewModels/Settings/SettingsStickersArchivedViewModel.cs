﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unigram.Services;

namespace Unigram.ViewModels.Settings
{
    public class SettingsStickersArchivedViewModel : SettingsStickersArchivedViewModelBase
    {
        public SettingsStickersArchivedViewModel(IProtoService protoService, ICacheService cacheService, IEventAggregator aggregator) 
            : base(protoService, cacheService, aggregator, false)
        {
        }
    }
}
