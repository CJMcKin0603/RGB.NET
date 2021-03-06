﻿using System;
using System.Collections.Generic;
using System.Linq;
using RGB.NET.Core;
using RGB.NET.Devices.Logitech.Native;

namespace RGB.NET.Devices.Logitech
{
    /// <inheritdoc />
    /// <summary>
    /// Represents the update-queue performing updates for logitech per-device devices.
    /// </summary>
    public class LogitechPerDeviceUpdateQueue : UpdateQueue
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogitechPerDeviceUpdateQueue"/> class.
        /// </summary>
        /// <param name="updateTrigger">The update trigger used by this queue.</param>
        public LogitechPerDeviceUpdateQueue(IDeviceUpdateTrigger updateTrigger)
            : base(updateTrigger)
        { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void Update(Dictionary<object, Color> dataSet)
        {
            Color color = dataSet.Values.First();

            _LogitechGSDK.LogiLedSetTargetDevice(LogitechDeviceCaps.DeviceRGB);
            _LogitechGSDK.LogiLedSetLighting((int)Math.Round(color.RPercent * 100),
                                             (int)Math.Round(color.GPercent * 100),
                                             (int)Math.Round(color.BPercent * 100));
        }

        #endregion
    }
}
